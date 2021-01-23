    DoesElementExistX(driver, sw, "//*[@id='openCloseWrap']/img");
    DoesElementExistX(driver, sw, "//*[@id='ButtonUSFlag']");
    DoesElementExistX(driver, sw, "//*[@id='ButtoFRFlag']");
    DoesElementExistX(driver, sw, "//*[@id='ImageButton1']");
    DoesElementExistX(driver, sw, "//*[@id='ButtonDEFlag']");
    DoesElementExistX(driver, sw, "//*[@id='ButtonITFlag']");
    DoesElementExistX(driver, sw, "//*[@id='ButtonSPFlag']");
        #region[DoesElementExistX]
        public static void DoesElementExistX(IWebDriver driver, StreamWriter sw, String id)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath(id)));
            }
            catch (WebDriverTimeoutException)
            {
                sw.WriteLine("FAILED - " + id);
            }
        }
        #endregion
