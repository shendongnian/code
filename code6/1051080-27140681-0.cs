    public static int intersection(int[] setA, int sizeA, int[] setB, int sizeB, int[] resultSet)
        {
            int copies = 0;
            for (int count = 0; count < sizeA; count++)
            {
                for (int x = 0; x < sizeB; x++)
                {
                    if (setA[count] == setB[x])
                    {
                        resultSet[copies] = setB[x];
                        copies++;
                    }
                }
            }
            return copies;
        }
