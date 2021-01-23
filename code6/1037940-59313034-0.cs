        private static int GetIdenticalPairCount(int[] input)
        {
            int identicalPairCount = 0;
            Dictionary<int, int> identicalCountMap = new Dictionary<int, int>();
            foreach (int i in input)
            {
                if (identicalCountMap.ContainsKey(i))
                {
                    identicalCountMap[i] = identicalCountMap[i] + 1;
                    if (identicalCountMap[i] > 1)
                    {
                        identicalPairCount += identicalCountMap[i];
                    }
                    else
                    {
                        identicalPairCount++;
                    }
                }
                else
                {
                    identicalCountMap.Add(i, 0);
                }
            }
            return identicalPairCount;
        }
