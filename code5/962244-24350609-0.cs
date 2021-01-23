    public static class ExtensioMethods
    {
        public static int Get(this int[,] array, Point p)
        {
            return array[p.X, p.Y];
        }
    }
