    public void TestMethod1Exists()
    {
        try
        {
            var classUnderTest = new ClassToTest();
            classUnderTest.Method1();
        }
        catch (Exception)
        {
        }
    }
