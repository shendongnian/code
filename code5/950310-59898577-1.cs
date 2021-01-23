    internal class SolverStepNakedSet : SolverStepSetBase
    {
        protected override bool SolveIt(SolutionManager solutionManager, int size)
        {
            foreach (var vSol in (from vec in solutionManager.Sudoku.Vectors
                                  from vSet in vec.GetSubSets(size, c => Enumerable.Range(2, size - 1).Contains(c.MyValue.OpenCandidates.Count()))
                                  let vValues = vSet.SelectMany(c => c.MyValue.OpenCandidates).Select(cc=> cc.Value).Distinct().ToList()
                                  where vValues.Count() == size
                                  let vLstCellsValues = (from vValue in vValues
                                                         let vLstCells = vec.FindAll(c => !vSet.Contains(c) && c.MyValue.OpenCandidates.Any(cc=>cc.Value==vValue))
                                                         where vLstCells.Count() > 0
                                                         select new SolutionValueElement(vValue, vLstCells))
                                  where vLstCellsValues.Count() > 0
                                  select new SolutionSet( Step, new SolutionValue(ValueState.Removal, vLstCellsValues), new Set(vSet.ToList(),vValues))))
            {
                if (solutionManager.Execute(vSol)) return true;
            }
            return false;
        }
    }
