            ITestManagementTeamProject teamProject = testManagementService.GetTeamProject(projectId);
            ITestPlan testplan= teamProject.TestPlans.Find(testplanId);
            IStaticTestSuite newSuite = teamProject.TestSuites.CreateStatic();
            newSuite.Title = "new title";
            testplan.RootSuite.Entries.Add(newSuite);
            testplan.Save();
