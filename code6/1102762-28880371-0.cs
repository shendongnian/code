    //This assumes you are already connected to ALM and your project.
    string testFolder = @"Root\whatever your folder name is";                    
                    
    TestSetFactory tstFactory = (TestSetFactory)qcConn.TestSetFactory;
    TestSetTreeManager tsTreeMgr = (TestSetTreeManager)qcConn.TestSetTreeManager;
    TestSetFolder tsFolder = (TestSetFolder)tsTreeMgr.get_NodeByPath(testFolder);
    List tsList = tsFolder.FindTestSets("MyTestSet", false, null);
    foreach (TestSet ts in tsList)
    {
        TestSetFolder tstFolder = (TestSetFolder)ts.TestSetFolder;
        TSTestFactory tsTestFactory = (TSTestFactory)ts.TSTestFactory;
        List mylist = tsTestFactory.NewList("");
        foreach (TSTest tsTest in mylist)
        {
            RunFactory runFactory = (RunFactory)tsTest.RunFactory;
            Run run = (Run)runFactory.AddItem("Name of your run here");
            run.CopyDesignSteps();
            run.Status = "Passed";
            run.Post();
            StepFactory stepFactory = (StepFactory)run.StepFactory;
            dynamic stepList = stepFactory.NewList("");
            var rstepList = (TDAPIOLELib.List)stepList;
            foreach (dynamic rstep in rstepList)
            {
                rstep.Status = "Passed";
                rstep.Post();
            }
        }
    }
