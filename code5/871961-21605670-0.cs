    public static class ArrayExt
    {
        public static T[] TakeLast<T>(this T[] inputArray, int count) where T: struct
        {
            count = Math.Min(count, inputArray.Length);
            int size = Marshal.SizeOf(typeof(T));
            T[] result = new T[count];
            Buffer.BlockCopy(inputArray, (inputArray.Length-count)*size, result, 0, count*size);
            
            return result;
        }
    }
