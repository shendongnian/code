    string tfsUri= <tfs uri like    @"https://<your tfs>/tfs/<your collection>"      >;
    string userName = <TFS user name>;
    string password = <password>,
    string projectName = <TFS project name>;
    int planId = <test plan id>;
    int suiteId = <test suite id>;
    int settingsId = <test settings id>;
    int configurationId = <test configuration id>;
    string environmentName = <test environment you want to run the tests on>;
    TfsTeamProjectCollection tfsCollection = new TfsTeamProjectCollection(new Uri(tfsUri), new System.Net.NetworkCredential(userName, password));
    tfsCollection.EnsureAuthenticated();
    
    ITestManagementService testManagementService = tfsCollection.GetService<ITestManagementService>();
    ITestManagementTeamProject project = testManagementService.GetTeamProject(projectName);
    
    //Get user name
    TeamFoundationIdentity tfi = testManagementService.AuthorizedIdentity;
    
    ITestPlan plan = project.TestPlans.Find(planId);
    ITestSuiteBase suite = project.TestSuites.Find(suiteId);
    ITestSettings testSettings = project.TestSettings.Find(settingsId);
    ITestConfiguration testConfiguration = project.TestConfigurations.Find(configurationId);
    
    // Unfortunately test environment name is not exactly the name you see in MTM.
    // In order to get the name of your environments just call
    // project.TestEnvironments.Query()
    // set a breakpoint, run this code in debuger and check the names.		
    ITestEnvironment testEnvironment = project.TestEnvironments.Find((from te in project.TestEnvironments.Query()
    																  where te.Name.ToUpper().Equals(environmentName.ToUpper())
    																  select te.Id).SingleOrDefault());
    
    testRun = plan.CreateTestRun(true);
    testRun.Owner = tfi;
    testRun.Controller = testEnvironment.ControllerName;
    testRun.CopyTestSettings(testSettings);
    testRun.TestEnvironmentId = testEnvironment.Id;
    testRun.Title = "Tests started from the dashboard";
    	
    //Get test points
    ITestPointCollection testpoints = plan.QueryTestPoints("SELECT * FROM TestPoint WHERE SuiteId = " + suite.Id + " and ConfigurationId = " + testConfiguration.Id);
    		
    foreach (ITestPoint tp in testpoints)
    {
    	testRun.AddTestPoint(tp, tfi);
    }
    // This call starts your tests!
    testRun.Save();
