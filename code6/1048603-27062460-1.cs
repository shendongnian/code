    [TestMethod]
    public void ConfigurationLoads()
    {
        const string configFile = @"C:\Users\Christopher\Source\Repos\RetailCoderVBE\RetailCoder.VBE\Config\rubberduck.config";
        IFileAccess fileAccess = Mock.Of<IFileAccess>();
        // setup fileAccess
        Rubberduck.Config.Configuration config = new ConfigLoader().LoadConfiguration(fileAccess);
        Assert.IsNotNull(config);
    }
