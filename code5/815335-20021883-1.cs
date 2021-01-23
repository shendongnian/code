    class Program
    {
        private static Program P;
        private static Program P1;
        string read = string.Empty;
        string write = string.Empty;
        static void Main(string[] args)
        {
            Anymethod();
            Console.WriteLine("==================P instance value=================");
            Console.WriteLine("Value read of instance 'P'  P.read ='{0}'", P.read);
            Console.WriteLine("Value write of Instance 'P' P.write='{0}'", P.write);
            //Same as the above code, only not using a String format
           // Console.WriteLine("Value read of instance 'P'  P.read ='" + P.read + "'");
           // Console.WriteLine("Value write of Instance 'P' P.write='" + P.write + "'");
            Console.WriteLine("==================P1 instance value===================");
            Console.WriteLine("Value read of instance 'P1'  P1.read ='{0}'", P1.read);
            Console.WriteLine("Value write of Instance 'P1' P1.write='{0}'", P1.write);
            //Same as the above code, only not using a String format
            // Console.WriteLine("Value read of instance 'P1'  P.read ='" + P1.read + "'");
            // Console.WriteLine("Value write of Instance 'P1' P.write='" + P1.write + "'");
            Console.WriteLine("==============Together=================");
            Console.WriteLine(P.read + P1.write);
            Console.ReadLine();
        }
        public static void Anymethod()
        {
            P = new Program();
            P1 = new Program();
            P.read = "Hello ";
            P1.write = " World";
        }
    }
