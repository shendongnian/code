    [ClassInitialize]
    public void classInitialize()
    {
        // Do some stuff, including launch the browser
        // This is executed once per class.
    }
    [TestInitialize]
    public void testInitialize()
    {
        // This is where you'd get the test back to a specific 
        // state, like bring your browser back to a home page or something.
        // It would be executed at the beginning of each test.
    }
    
    ....
    
    [TestMethod]
    public void myFirstTest()
    {
        // Do some more stuff specific to your test.
    }
    
    [TestMethod]
    public void mySecondTest()
    {
        // Do things after the last test.
    }
    ....
    [ClassCleanup]
    public void classCleanup()
    {
        // Finalize everything and close the browser.
    }
