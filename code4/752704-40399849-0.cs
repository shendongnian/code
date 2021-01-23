    [Test, TestCaseSource("DivideCases")]
    public void DivideTest(int n, int d, int q)
    {
        Assert.AreEqual( q, n / d );
    }
    
    static object[] DivideCases =
    {
        new object[] { 12, 3 },
        new object[] { 12, 2 },
        new object[] { 12, 4 } 
    };
