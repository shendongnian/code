    try
    {
         for(int i=0; i<10; i++)
         {
              string className = "items-" + i;
              By locatorFunction = By.CssSelector("[class$='" + className + "'] > span")
              IWebElement t = Driver.FindElement(locatorFunction);
              t.Click();
         }
    }
    catch (NoSuchElementException ex)
    {
         Logger.Error("Error: " + ex.Message);
         Logger.Error("Unable to find element using function " + locatorFunction.ToString());
         Debug.WriteLine(ex.Message);
    }
