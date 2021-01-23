    private void RunTest(Action<SSGForm> action)
    {
        WorkbookSet workbookSet = Factory.GetWorkbookSet(CultureInfo.CurrentCulture);
        Workbook workbook = workbookSet.Workbooks.Add();
        workbookSet.GetLock();
        try
        {
            string testScriptPath = Path.Combine(
            Environment.CurrentDirectory, "Scripts\\Test.xlsx");
            SSGForm doc = new SSGForm();
            if (Utils.FileExists(testScriptPath))
                mainRibbonForm.OpenExistingWb(ref doc, ref workbookSet, ref workbook, testScriptPath);
    
            // Run the test logic.
            action(doc);
        }
        finally
        {
            workbookSet.ReleaseLock();
        }
    }
    
    [TestMethod]
    public void SomeTest()
    {
        RunTest(doc =>
            {
                // Logic here.
                Foo(doc);
            });
    }
