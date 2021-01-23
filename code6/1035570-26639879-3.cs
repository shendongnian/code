    By locator;     // need to declare this outside the scope of the try block
                    // so it can be accessed in the catch block
    try
    {
         for(int i=0; i<10; i++)
         {
              string className = "items-" + i;
              locatorFunction = By.CssSelector("[class$='" + className + "'] > span")
              IWebElement t = Driver.FindElement(locatorFunction);
              t.Click();
         }
    }
    catch (NoSuchElementException ex)
    {
         Logger.Error("Error: " + ex.Message);
         Logger.Error("Error: Unable to find element using function " + locatorFunction.ToString());
    }
