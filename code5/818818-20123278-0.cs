    public void TestSomething() 
    {
        var result1 = false;
        try 
        {
            testedClass.testedMethod(null);
            result1 = true;
        }
        catch (IllegalArgumentException ex) { }
        var result2 = SomeDetailedTest();
        var expected = new Object[] { false, 42 };
        var actual =  new Object[] { result1, result2 };
        Assert.AreEqual(expected, actual);
    } 
