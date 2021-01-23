        TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://my-tfs:8080/tfs/DefaultCollection"));
        ITestManagementService tms = tpc.GetService<ITestManagementService>();
        ITestManagementTeamProject tmtp = tms.GetTeamProject("My Project");
        ITestRunHelper testRunHelper = tmtp.TestRuns;
        IEnumerable<ITestRun> testRuns = testRunHelper.ByBuild(new Uri("vstfs:///Build/Build/123456"));
        var failedRuns = testRuns.Where(run => run.QueryResultsByOutcome(TestOutcome.Failed).Any()).ToList();
        failedRuns.First().Attachments[0].DownloadToFile(@"D:\temp\myfile.trx");
