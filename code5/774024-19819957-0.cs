        public int solution(int X, int[] A)
        {
                    int steps = -1;
            bool[] tiles = new bool[X];
            int todo = X;
            for (int i = 0; i < A.Length; i++)
            {
                steps += 1;
                int internalIndex = A[i] - 1;
                if (internalIndex < tiles.Length)
                {
                    if (!tiles[internalIndex])
                    {
                        todo--;
                        tiles[internalIndex] = true;
                    }
                }
                if (todo == 0)
                    return steps;
            }
            return -1;
        }
