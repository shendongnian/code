    class P
    {
        static void M(params System.Collections.Generic.List<string>[] p) {}
        static void M(params int[] p)  {}
        static void Main()
        {
            M();
        }
    }
