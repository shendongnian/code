    class Program
    {
        static void Main(string[] args)
        {
            int integer;
            Method(out integer);
            // integer is now 9
        }
        static void Method(out int pointer)
        {
            ...
            pointer = 9;
        }
    }
    // Option 2:
    class Program
    {
        static void Main(string[] args)
        {
            int integer = 9;
            Method(integer);            
        }
        static void Method(int pointer)
        {            
            //Do something with pointer = 9
        }
    }
