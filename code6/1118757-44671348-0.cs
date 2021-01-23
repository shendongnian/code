    static void ClickElement_ByID(string elementName)
        {
            try
            {
                IWebElement test = driver.FindElement(By.Id(""+elementName+""));
                Console.WriteLine("Found: "+elementName);
                test.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
