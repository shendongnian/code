    [Binding]
    public class TestsRunner
    {
        [AfterScenario]
        public void TakeScrennShot()
        {
            if(ScenarioContext.Current.TestError != null)
            {
                WebBrowser.TakeScreenShot(); // Your custom browser take screenshot method for example
            }
        }
    }
