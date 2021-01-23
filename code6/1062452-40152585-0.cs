    static public bool verify(string elementName)
        {
            try
            {
                bool isElementDisplayed = driver.FindElement(By.XPath(elementName)).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
        static void testfunc()
        {
           bool test = verify("//option[contains(.,'English')]");
            Console.WriteLine(test);
           
        }
