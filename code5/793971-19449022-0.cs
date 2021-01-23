    [TestMethod]
    public void JoinStringsViaAggregate()
    {
        var mystrings = new[] {"Alpha", "Beta", "Gamma"};
        var result = mystrings.Aggregate((x, y) => x + ", " + y);
        Assert.AreEqual("Alpha, Beta, Gamma", result);
    }
