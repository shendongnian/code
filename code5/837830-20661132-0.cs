    private string path =  @"C:\TestFiles\";
    [SetUp]
    public void Setup()
    {
        Directory.CreateDirectory(path);        
    }
    
    [TearDown]
    public void Deardown()
    {
         Directory.Delete(path);
    }
    
    [Test]
    public void ShouldRemoveAllFilesFromSpecifiedDirectory()
    {
        // seed directory with sample files
        FileUtility.DeleteXmlFiles(path);
        Assert.False(Directory.EnumerateFiles(path).Any());
    }
