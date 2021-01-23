    void Test()
    {
        var list = new List<PositiveInteger> {5, 1, 3};
        list.Sort();  // 1,3,5
        var a = new PositiveInteger(1);
        var b = new PositiveInteger(2);
        var c = a + b;    // = 3
        var d = c - b;    // = 1
        var e = d - a;    // throws ArgumentOutOfRangeException
    }
