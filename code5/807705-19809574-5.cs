    public static class ArrayExt
    {
        public static Nullable<T> GetValueOrNull(this T[] array, int index) where T: struct
        {
            return array.Length < index ? new Nullable<T>(array[index]) : null;
        }
    }
