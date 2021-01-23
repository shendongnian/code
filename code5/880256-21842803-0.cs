    public static class MyExtensions
    {
        public static int[] GetValues(this Array source, int x, int y)
        {
            var length = source.GetUpperBound(2);
            var values = new int[length+1];
            for (int i = 0; i < length+1; i++)
            {
                values[i] = (int)source.GetValue(x, y, i);
            }
            return values;
        }
    }
