        foreach (ITestCaseResult testCaseResult in failures)
        {
            string testName = testCaseResult.TestCaseTitle;
            ITmiTestImplementation testImplementation = testCaseResult.Implementation as                 ITmiTestImplementation;
        string assembly = testImplementation.Storage;
        }
 
