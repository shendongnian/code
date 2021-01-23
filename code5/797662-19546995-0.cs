    using RGiesecke.DllExport;
    
    namespace ClassLibrary1
    {
        public static class Class1
        {
            [DllExport]
            public static int Hello()
            {
                return 1;
            }
    
            [DllExport]
            public static void Nope()
            {
            }
        }
    }
