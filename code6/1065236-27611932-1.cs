    string currentHandle = driver.CurrentWindowHandle;
    ReadOnlyCollection<string> originalHandles = driver.WindowHandles;
    // Cause the popup to appear
    driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']")).Click();
    // Wait for the handle count to increase. Note that this
    // is just being thorough; you *might* be able to get away
    // with avoiding this step.
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    wait.Until<bool>((d) =>
    {
        return driver.CurrentWindowHandles.Count > originalHandles.Count;
    });
    // Subtract out the list of known handles. In the case of a single
    // popup, the newHandles list will only have one value.
    List<string> newHandles = driver.CurrentWindowHandles.Except(originalHandles).ToList();
    
    driver.SwitchTo().Window(newHandles[0]);
    // Do whatever you need to on the popup browser, then...
    driver.Close();
    driver.SwitchToWindow(currentHandle);
