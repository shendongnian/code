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
                    if (lastError is OpenQA.Selenium.NoSuchElementException)
                    {
                        // Test failure cause by not finding an element on the page
                    }
                }
            }
        }
    }
