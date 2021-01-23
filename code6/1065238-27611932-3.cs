    string currentHandle = driver.CurrentWindowHandle;
    ReadOnlyCollection<string> originalHandles = driver.WindowHandles;
    // Cause the popup to appear
    driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']")).Click();
    // WebDriverWait.Until<T> waits until the delegate returns
    // a non-null value for object types. We can leverage this
    // behavior to return the popup window handle.
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    string popupWindowHandle = wait.Until<string>((d) =>
    {
        string foundHandle = null;
        // Subtract out the list of known handles. In the case of a single
        // popup, the newHandles list will only have one value.
        List<string> newHandles = driver.CurrentWindowHandles.Except(originalHandles).ToList();
        if (newHandles.Count > 0)
        {
            foundHandle = newHandles[0];
        }
        return foundHandle;
    });
    
    driver.SwitchTo().Window(popupWindowHandle);
    // Do whatever you need to on the popup browser, then...
    driver.Close();
    driver.SwitchToWindow(currentHandle);
