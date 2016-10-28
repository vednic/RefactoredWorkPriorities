using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RWP
{
    public class WorkGiver_RemoveRoofSpecial : WorkGiver_RemoveRoof
	{
        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
        {
            foreach (IntVec3 cell in Find.AreaNoRoof.ActiveCells)
            {
                List<Thing> thing = Find.ThingGrid.ThingsListAt(cell);
                for (int i = 0; i < thing.Count; i++)
                {
                    if (thing[i].def.holdsRoof && Find.DesignationManager.DesignationOn(thing[i]) == null)
                    {
                        Find.DesignationManager.AddDesignation(new Designation(thing[i], DesignationDefOf.Deconstruct));
                        yield return thing[i];
                    }
                }
            }
        }
    }
}