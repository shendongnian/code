    [AfterStep]
        public void check()
        {
            var exception = ScenarioContext.Current.TestError;
            if (exception is WebDriverException 
                && exception.Message.Contains("The HTTP request to the remote WebDriver server for URL "))
            {
                Assert.Inconclusive(exception.Message);
            }
        }
