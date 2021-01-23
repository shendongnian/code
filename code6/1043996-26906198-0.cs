    [FindsBy(How = How.Id, Using = "search-criteria")]
            public IWebElement txtProductSearch1 = null
    public void copypaste(string strCopy)
          { 
                    txtProductSearch1.Click();
                    txtProductSearch1.Clear();
                    txtProductSearch1.SendKeys(strCopy);
                    txtProductSearch1.SendKeys(Keys.Control + "a"); //a in smaller case
                    txtProductSearch1.SendKeys(Keys.Control + "c"); // c in smaller case
                    txtProductSearch1.Clear();
                    txtProductSearch1.SendKeys(Keys.Control + "v"); // v in smaller case
                    btnProductSearch1.Click();
           }
