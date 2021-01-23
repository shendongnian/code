    [DllImport("Lks.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void DON(
            [MarshalAs(UnmanagedType.R8)]     double DAA,
            [MarshalAs(UnmanagedType.R8)] ref double DBB,
            [MarshalAs(UnmanagedType.R8)] ref double DCC
            );
    
        static unsafe void Main(string[] args)
        {
            //double TIME = 100.0;
            double DAA = 5.5;
            double DBB = 7;
            double DCC = 9;
            //START( ENERIN, VAL1);
            DON(DAA, DBB, DCC);
    
            Console.Write("val1 = " + DAA);
            Console.Write("val2 = " + DCC);
            Debug.WriteLine("VAR = " + DBB.ToString());
            Console.Write("Press any key to exit");
            Console.ReadKey(false);
        }
