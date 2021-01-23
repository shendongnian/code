        enter code here
    public static int[] GetMaxValues(int[,] Arr)
            {
                int[] Max = new int[Arr.GetLength(0)];
    
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    Max[i] = int.MinValue;
                    for (int l = 0; l < Arr.GetLength(1); l++)
                        if (Arr[i, l] > Max[i])
                            Max[i] = Arr[i, l];
                }
    
                return Max;
            }
