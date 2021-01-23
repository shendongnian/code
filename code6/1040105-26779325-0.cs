    [BeforeScenario()]
    public static void BeforeWebScenario()
    {
        if(!ScenarioContext.Current.ScenarioInfo.Tags.Contains("noReducedTimeout"))
            AddReducedTimeout;
    }
