    [Binding]
    public class TestsRunner
    {
        [AfterScenario]
        public void TakeScreenShot()
        {
            if(ScenarioContext.Current.TestError != null)
            {
                WebBrowser.TakeScreenShot(); // Your custom browser take screenshot method 
            }
        }
    }
