    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.test();
        }
        void Test()
        {
            // I'm NOT static
            // I belong to an instance of the 'Program' class
            // You must have an instance to call me
        }
    }
