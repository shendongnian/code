    // named and nameless
    [Export("TypeA", typeof(MyPlugin))]
    [Export(typeof(MyPlugin))]
    // named nameless, again
    [Export("TypeB", typeof(MyPlugin))]
    [Export(typeof(MyPlugin))]
    class MyPlugin { }
    [TestMethod]
    public void mef()
    {
        var catalog = new AssemblyCatalog(this.GetType().Assembly);
        var container = new CompositionContainer(catalog);
        Assert.AreEqual(2, container.GetExportedValues<MyPlugin>().Count());
    }
