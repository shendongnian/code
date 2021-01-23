    static int Threshold = 30;
        public static List<long> RandomMethod(long Target)
        {
            List<long> Combinations = new List<long>();
            Random rnd = new Random();
            //Assuming establishedValues is sorted
            int LowerBound = 0;
            long runningSum = Target;
            while (true)
            {
                int newLowerBound = FindLowerBound(LowerBound, runningSum);
                if (newLowerBound == -1)
                {
                    //No more beneficial values to work with, reset
                    runningSum = Target;
                    Combinations.Clear();
                    LowerBound = 0;
                    continue;
                }
                LowerBound = newLowerBound;
                int rIndex = rnd.Next(LowerBound, establishedValues.Count);
                long val = establishedValues[rIndex];
                runningSum -= val;
                Combinations.Add(val);
                if (Math.Abs(runningSum) <= 30)
                    return Combinations;
            }
        }
        static int FindLowerBound(int currentLowerBound, long runningSum)
        {
            //Adjust lower bound, so we're not randomly trying a number that's too high
            for (int i = currentLowerBound; i < establishedValues.Count; i++)
            {
                //Factor in the threshold, because an end aggregate which exceeds by 20 is better than underperforming by 21.
                if ((establishedValues[i] - Threshold) < runningSum)
                {
                    return i;
                }
            }
            return -1;
        }
