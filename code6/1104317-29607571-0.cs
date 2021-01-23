    try
    {
        if (qcConn.Connected)
        {
            string testFolder = @"Root\YourFolder";
            TestSetTreeManager tsTreeMgr = (TestSetTreeManager)qcConn.TestSetTreeManager;
            TestSetFolder tsFolder = (TestSetFolder)tsTreeMgr.get_NodeByPath(testFolder);
            AttachmentFactory attchFactory = (AttachmentFactory)tsFolder.Attachments;
            List tsList = tsFolder.FindTestSets("YourTestNameHere", false, null);
            foreach (TestSet ts in tsList)
            {
                TestSetFolder tstFolder = (TestSetFolder)ts.TestSetFolder;
                TSTestFactory tsTestFactory = (TSTestFactory)ts.TSTestFactory;
                List mylist = tsTestFactory.NewList("");
                foreach (TSTest tsTest in mylist)
                {
                    RunFactory runFactory = (RunFactory)tsTest.RunFactory;
                    Run run = (Run)runFactory.AddItem("NameYouWantDisplayedInALMRuns");
                    run.CopyDesignSteps();
                    //runResult just tells me if overall my test run passes or fails - it's not built in. It was my way of tracking things though the code.
                    if(runResult)
                        run.Status = "Failed";
                    else
                        run.Status = "Passed";
                    run.Post();
                    //Code to attach an actual file to the test run.
                    AttachmentFactory attachmentFactory = (AttachmentFactory)run.Attachments;
                    TDAPIOLELib.Attachment attachment = (TDAPIOLELib.Attachment)attachmentFactory.AddItem(System.DBNull.Value);
                    attachment.Description = "Attach via c#";
                    attachment.Type = 1;
                    attachment.FileName = "C:\\Program Files\\ApplicationName\\demoAttach.txt";
                    attachment.Post();
                    //Code to attach a URL to the test run
                    AttachmentFactory attachmentFactory = (AttachmentFactory)run.Attachments;
                    TDAPIOLELib.Attachment attachment = (TDAPIOLELib.Attachment)attachmentFactory.AddItem(System.DBNull.Value);
                    //Yes, set the description and FileName to the URL.
                    attachment.Description = "http://www.google.com";
                    attachment.Type = 2;
                    attachment.FileName = "http://www.google.com";
                    attachment.Post();
                    
                    //If your testset has multiple steps and you want to update 
                    //them to pass or fail
                    StepFactory rsFactory = (StepFactory)run.StepFactory;
                    dynamic rdata_stepList = rsFactory.NewList("");
                    var rstepList = (TDAPIOLELib.List)rdata_stepList;
                    foreach (dynamic rstep in rstepList)
                    {
                        if (SomeConditionFailed)
                                rstep.Status = "Failed";
                            else
                                rstep.Status = "Passed";
                            rstep.Post();
                        }
                        else
                        {
                            rstep.Status = "No Run";
                            rstep.Post();
                        }
                    }
                }
            }
        }
    }
