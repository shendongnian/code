    // doesn't allocate (in the foreach loop)
    public static void TestHash()
    {
        HashSet<int> foo = new HashSet<int> { 1 };
        foreach (int bar in foo) {
            NoOp(bar);
        }
    }
    
    // allocates
    public static void TestIList()
    {
        IList<int> foo = new List<int> { 1 };
        foreach (int bar in foo) {
            NoOp(bar);
        }
    }
    
    // doesn't allocate; even more optimized
    public static void TestArray()
    {
        int[] foo = new int[] { 1 };
        foreach (int bar in foo) {
            NoOp(bar);
        }
    }
