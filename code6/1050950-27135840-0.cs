    private SomeMethod(List<string> s)
    {
        Assert.IsNotNull(s);
        Assert.AreEqual(1, s.Count);
    }
    
    clientSearchAsync("Getting", SomeMethod, Assert.IsNull);
