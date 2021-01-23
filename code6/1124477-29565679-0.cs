    Driver.FindElement(By.TagName("test")).Click();
    
    //Make sure the click above generates the alert
    String text = (new WebDriverWait(Driver, TimeSpan.FromSeconds(10))).Until(d => d.SwitchTo().Alert().Text);
    Assert.IsTrue(text.Contains("The username and/or password entered are invalid."));
