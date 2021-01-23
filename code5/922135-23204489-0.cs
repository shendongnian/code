    IWebElement ddl = driver.FindElement(By.Id("ctl03_ctl00_ctl00_Tabbed_ContentPlaceHolder_ContentPlaceHolder1_ContentPlaceHolder1_ctl00_ctl00_gvQuestions_ctl03_cblListItems2_Arrow"));
    ddl.Click();
    IList<IWebElement> lis = driver.FindElements(By.ClassName("rcbItem"));
    foreach (IWebElement li in lis)
        try
        {
            IWebElement checkBox = li.FindElement(By.ClassName("rcbCheckBox"));
            //if (checkBox.Selected)
            checkBox.Click();
            break;
        }
        catch {}
