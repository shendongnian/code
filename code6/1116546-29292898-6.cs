          int[][] a = { new int[] { 1, 2, 3, 4 }, new int[] { 3, 9, 9 } };
            int[] b = new int[] { 5, 6, 1, 2, 7, 8 };
            int Count = 0;
            for (int h = 0; h < a.Length; h++)
            {
                for (int i = 0; i < a[h].Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (b[j] == a[h][i])
                        {
                            Count++;
                            break;
                        }
                    }
                }
            }
