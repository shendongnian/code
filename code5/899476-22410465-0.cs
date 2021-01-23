    public static class Extensions
    {
        public static void FindCoordinates<T>(this T[,] source, int index, out int x,out int y)
        {
            int counter = 0;
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    counter++;
                    if (counter == index)
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
