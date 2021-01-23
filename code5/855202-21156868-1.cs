    public static IWebElement ClickOnInvisibleElement(this IWebDriver Driver, By by)
    {
         IWebElement element = Driver.FindElement(by))
         ((IJavaScriptExecutor)Driver).ExecuteScript(("arguments[0]document.hidden = false;", element);
         element.click
         ((IJavaScriptExecutor)Driver).ExecuteScript(("arguments[0]document.hidden = true;", element);
         return element;
    }
    Driver.ClickOnInvisibleElement(By.XPath("//input[@value=2]"));
