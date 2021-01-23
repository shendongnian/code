    [Test, TestCaseSource("Test_Source")]
    [Category("Unit")]
    public void Method_test(TestObject testObject)
    {
        String actual = MethodCall(testObject.In1, testObject.In2);
        Assert.AreEqual(testObject.Expected, actual, "Poof");
    }
