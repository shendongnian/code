        static int Threshold = 30;
        private static Stack<long> RecursiveMethod(long target)
        {
            Stack<long> Combination = new Stack<long>(establishedValues.Count); //Can grow bigger, as big as (target / min(establishedValues)) values
            Stack<int> Index = new Stack<int>(establishedValues.Count); //Can grow bigger
            int lowerBound = 0;
            int dimensionIndex = lowerBound;
            long fail = -1 * Threshold;
            while (true)
            {
                long thisVal = establishedValues[dimensionIndex];
                dimensionIndex++;
                long afterApplied = target - thisVal;
                if (afterApplied < fail)
                    lowerBound = dimensionIndex;
                else
                {
                    target = afterApplied;
                    Combination.Push(thisVal);
                    if (target <= Threshold)
                        return Combination;
                    Index.Push(dimensionIndex);
                    dimensionIndex = lowerBound;
                }
                if (dimensionIndex >= establishedValues.Count)
                {
                    if (Index.Count == 0)
                        return null; //No possible combinations
                    dimensionIndex = Index.Pop();
                    lowerBound = dimensionIndex;
                    target += Combination.Pop();
                }
            }
        }
