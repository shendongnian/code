    [TestMethod]
    public void TestSize()
    {
        MyStruct s = new MyStruct();
        Debug.Print(Marshal.SizeOf(s).ToString());
    }
