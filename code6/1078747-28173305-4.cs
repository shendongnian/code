    [Binding]
    public class CommonHooks
    {
        public CommonHooks(ScenarioContext currentScenario)
        {
            this.currentScenario = currentScenario;
        }
        private ScenarioContext currentScenario;
        [AfterScenario]
        public void AfterScenario()
        {
            Exception lastError = currentScenario.TestError;
            if (lastError != null)
            {
                if (lastError is OpenQA.Selenium.NoSuchElementException)
                {
                    // Test failure cause by not finding an element on the page
                }
            }
        }
    }
