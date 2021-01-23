    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    
    namespace SeleniumTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
    
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
    
        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    
        public void TheCTest()
        {
            try
            {
                driver = new FirefoxDriver();
                baseURL = "http://uk.advfn.com";
                verificationErrors = new StringBuilder();
                driver.Navigate().GoToUrl(baseURL + "/common/account/login");
                driver.FindElement(By.Id("login_username")).Clear();
                driver.FindElement(By.Id("login_username")).SendKeys("demouser");
                driver.FindElement(By.Id("login_password")).Clear();
                driver.FindElement(By.Id("login_password")).SendKeys("demopass");
                driver.FindElement(By.Id("login_submit")).Click();
                Thread.Sleep(30000);
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
                foreach (DataGridViewRow row in dataGridView_FetchTickers.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        try
                        {
                            driver.Navigate().GoToUrl(baseURL + "/p.php?pid=data&daily=0&symbol=L%5E" + row.Cells[1].Value.ToString());
                            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
                            Thread.Sleep(30000);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
    
                    }
                    else
                    {
                        //Do nothing
                    }
                }
            }
            catch (Exception)
            {
                //
            }  
        }
    
        private void btn_fetchSharePrices_Click(object sender, EventArgs e)
        {
            TheCTest();
        }
    }
