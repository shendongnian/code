    class Program
    {
        public static int[] ints(params int[] values)
        {
            return values;
        }
        class BaseArray : BoundedArray<int>
        {
            public BaseArray()
            {
                Lengths = ints(1, 2);
                LowerBounds = ints(2, 2);
                CreateInstance();
            }
        }
        class SubArray : BoundedArray<BaseArray>
        {
            public SubArray(BaseArray arr)
            {
                Lengths = ints(2);
                LowerBounds = ints(4);
                
                CreateInstance(arr.GetData());
            }
        }
        static void Main(string[] args)
        {
            BaseArray baseArray = new BaseArray();
            SubArray subArray = new SubArray(baseArray);
            Console.Read();
        }
    }
