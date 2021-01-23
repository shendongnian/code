    pulic bool ElementExist(IWebDriver driver)
    {
     var value = false;
     var objWait = new WebDriverWait(driver, Timespan.FromMilliseconds(10000));
     objWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
     value = objWait.Until(b=>b.FindElements(By.TagName("div")).Count > 0);
   
     return value;
    }
