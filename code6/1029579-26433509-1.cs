    void Test()
    {
        var a = new PositiveInteger(1);
        var b = new PositiveInteger(2);
        var c = a + b;    // = 3
        var d = c - b;    // = 1
        var e = d - a;    // throws ArgumentOutOfRangeException
    }
