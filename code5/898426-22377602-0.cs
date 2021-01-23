    class Util
        {
            public static bool quiet;                //  flag to shut off o() Console output
            public static StreamWriter fOut;         //  the output file for o()
            public static int debugLevel = 2;
    
            public static void o(string s)
            {    
                if (!quiet)
                {
                    Console.WriteLine(s);
                }
    
                if (fOut != null)
                {
                    fOut.WriteLine(s);
                }
            }
    
            public static void o2(string s)
            {
                if (debugLevel >= 2)
                {
                    o(s);
                }
            }
    }
