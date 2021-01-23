    private static int runs = 0;
    [ClassInitialize]
    public static void SetUpBrowser(TestContext context)
    {
        pageObjectBase.SetBrowser("chrome");
        pagesManager.GetPageObjectBase();
    }
    [TestMethod]
    public void FindCriticalBug()
    {
        runs++;
        bla-bla-bla();
    }
    [TestMethod]
    public void FindCriticalBug2()
    {
        runs++;
        ble-ble-ble();
    }
    [TestCleanup]
    public static void CloseBrowser()
    {
        if (runs == 2)
        {
            pageObjectBase.Stop();
            pagesManager.GeneralClearing();
        }
    }
