    public static class ArrayExt
    {
        public static Nullable<T> NullIfEmpty(this T[] array, int index)
        {
            return array.Length < index ? new Nullable<T>(array[index]) : null;
        }
    }
