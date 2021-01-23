    public class CustomScreenshot
        {
        private IWebDriver _webDriver;
        public CustomScreenshot(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
 
    public void TakeScreenshotOnExecute(object sender, WebDriverScriptEventArgs e)
        {
            var filePath = "Where you want to save the file.";
            try
            {
                _webDriver.TakeScreenshot().SaveAsFile(filePath, ImageFormat.Png);
            }
            catch (Exception)
            {
                //DO something
            }
        }
    }
            
