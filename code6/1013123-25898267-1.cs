    IWebElement  container = driver.FindElement(By.ClassName("sublist"));
    IList<IWebElement> elements = container.FindElements(By.TagName("a"));       
    string[] newlink = new string[elements.Count];
    for (int i = 0; i < newlink.Count; i++)
    {
        newlink[i] = elements[i].Text;
    }
    for (int i = 0; i < newlink.Count; i++)
    {
        if (newlink[i] != null)
        {
            driver.FindElement(By.LinkText(newlink[i])).Click();
            driver.WaitForElement(By.CssSelector("[id$='hlnkPrint']"));
            driver.Navigate().Back();
        }
    }
