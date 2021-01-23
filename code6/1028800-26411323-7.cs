    class IntWrapper
    {
        public int value;
        public IntWrapper(int value)
        {
            this.value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IntWrapper> test = new List<IntWrapper>() { new IntWrapper(1), new IntWrapper(2), new IntWrapper(3), new IntWrapper(4), new IntWrapper(5) };
            foreach (IntWrapper i in test.Where(i => i.value == 1))
            {
                i.value = 0;
            }
            foreach (IntWrapper i in test)
            {
                Console.WriteLine(i.value);
            }
            Console.ReadLine();
        }
    }
