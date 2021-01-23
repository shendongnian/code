    using TechTalk.SpecFlow;
    namespace Your.Project
    {
        [Binding]
        public class CommonHooks
        {
            [AfterScenario]
            public void AfterScenario()
            {
                Exeception lastError = ScenarioContext.Current.TestError;
                if (lastError != null)
                {
                    // Do something with it
                }
            }
        }
    }
