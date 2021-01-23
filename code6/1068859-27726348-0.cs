    public static class ArrayExtensions
    {
        // Returns the index if it falls within the range of 0 to array.Length -1
        //  Otherwise, returns a minimum value of 0 or max of array.Length - 1
        public static int RangeCheck(this Array array, int index)
        {
            return Math.Max(Math.Min(index, array.Length - 1), 0);
        }
    }
