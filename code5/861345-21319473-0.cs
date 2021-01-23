    public static class ArrayExtender
    {
        public static T GetValue<T>(this T[,] array, params int[] indices)
        {
            return (T)array.GetValue(indices);
        }
        public static void SetValue<T>(this T[,] array, T value, params int[] indices)
        {
            array.SetValue(value, indices);
        }
        public static T ExchangeValue<T>(this T[,] array, T value, params int[] indices)
        {
            var previousValue = GetValue(array, indices);
            array.SetValue(value, indices);
            return previousValue;
        }
    }
