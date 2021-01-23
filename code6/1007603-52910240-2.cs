    public struct MyStruct
    {
        public int A;
    }
    public static class Program
    {
        public static MyStruct X;
        public static void Main()
        {
            Program.X.A = 1337;
            Program.DoIt();
        }
        public static void DoIt()
        {
            Program.PrintA(Program.X);
            Program.PrintType(Program.X);
        }
        private static void PrintType(object obj)
        {
            Console.WriteLine(obj.GetType().FullName);
        }
        public static void PrintA(MyStruct myStruct)
        {
            Console.WriteLine(myStruct.A);
        }
    }
