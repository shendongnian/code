    public static class MyExtensions
    {
        public static void FindAvailablePosition<T>(this T[,] source, out int x, out int y)
        {
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    if (source[i, j].Equals(default(T)))
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
            x = -1;
            y = -1;
        }
    }
