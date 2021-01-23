    public static class helper
    {
        public static UInt16[] ToUnit16(this byte[] arr)
        {
            if (arr == null)
                return null;
            var len = arr.Length;
            if ((len % 2) != 0)
                throw new ArgumentException("Must divide by 2");
            var count = len / 2;
            var result = new UInt16[count];
            do
            {
                result[--count] = (UInt16)((arr[--len]) | arr[--len] << 8);
            } while (count > 0);
            return result;
        }
    }
