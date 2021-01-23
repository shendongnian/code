    [TestMethod()]
    public void CalculateSomething1()
    {
        // First we have to define the input for the fucntion
        var input = new SomeInput1(); // Assumes your constructor creates the value for prop1 and prop2.  Change as needed.
        
        var classToBeTested = new CalculateSomething();
        var output = classToBeTested(input);
        
        // There are multiple ways to test if the outcome is correct choose the one that is correct for the method/output.
        Assert.IsNotNull(output);
    }
