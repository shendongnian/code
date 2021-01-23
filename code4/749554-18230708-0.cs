        static int GetMinCollatz(int maxChain)
        {
            const int number = 1000000;
           
            int minNumber = 0;
            // Temporary values
            int tempCount = 0;
            long temp = 0;
            // Cache 
            int[] sequenceCache = new int[number + 1];
            // Fill the array with -1
            for (int index = 0; index < sequenceCache.Length; index++)
            {
                sequenceCache[index] = -1;
            }
            sequenceCache[1] = 1;
            for (int index = 2; index <= number; index++)
            {
                tempCount = 0;
                temp = index;
                // If the number is repeated then we can find 
                // sequence count from cache
                while (temp != 1 && temp >= index)
                {
                    if (temp % 2 == 0)
                        temp = temp / 2;
                    else
                        temp = temp * 3 + 1;
                    tempCount++;
                }
                sequenceCache[index] = tempCount + sequenceCache[temp];
                if (sequenceCache[index] == maxChain)
                {
                    minNumber = index;
                }
            }
           
            return minNumber;
        }
