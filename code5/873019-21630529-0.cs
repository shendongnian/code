namespace DriveInfos
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.propertyInt = 5;
            Console.WriteLine(prog.propertyInt);
            Console.Read();
        }
        class Program1
        {
            public int propertyInt
            {
                get { return 1; }
                set { Console.WriteLine(value); }
            }
        }
    }
}
