    public IEnumerable<ColorType> TestCaseSource 
    { 
        get
        {
            int start = (int)ColorType.None;
            int count = (int)ColorType.All - start + 1;
            return Enumerable.Range(start, count).Select(i => (ColorType)i); 
        } 
    }
    [TestCaseSource("TestCaseSource")]
    public void Test1(ColorType colorType)
    {
        // whatever your test is
    }
