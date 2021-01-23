    TestResult ExecuteTests(string testAssemblyPath) {
        CoreExtensions.Host.InitializeService();
        TestPackage testPackage = new TestPackage(testAssemblyPath);
        testPackage.BasePath = Path.GetDirectoryName(testAssemblyPath);
    
        RemoteTestRunner testRunner = new RemoteTestRunner();
        testRunner.Load(testPackage);
                    
        TestResult testResult = testRunner.Run(new NullListener(), TestFilter.Empty, true, LoggingThreshold.Warn);
        testRunner.Unload();
        CoreExtensions.Host.UnloadService();
    
        return testResult;
    }
