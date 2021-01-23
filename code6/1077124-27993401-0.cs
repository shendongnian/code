    var myWebElement = Driver.FindElement(By.XPath("//a[.=' some value']
    WebDriverWait wait = new WebDriverWait(Driver.FindElement, TimeSpan.FromSeconds(10));
    var element = wait.Until(ExpectedConditions.ElementIsVisible(myWebElement));
    Actions action  = new Actions(Driver.FindElement);
    action.MoveToElement(element).Perform();
    myWebElement.Click();
