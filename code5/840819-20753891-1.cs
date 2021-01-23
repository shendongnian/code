    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    namespace ConsoleApplication4
    {
        class Program
        {
            //Locators: Generated with SWD Page Recorder; Template=[CSharp] Locator constants in the static class
            public static class LoginLocators
            {
                public const string txtEmail_XPath = @"id(""email"")";
                public const string txtPassword_XPath = @"id(""pass"")";
                public const string btnLogin_XPath = @"id(""loginbutton"")";
            }
            
            public static class PostLocators
            {
                public const string txtWhatsOnYourMind_XPath = @"//textarea[contains(@title,""What's on your mind?"")]";
                public const string btnPost_XPath = @"//button[contains(text(), 'Post')]";
                public const string userPostsList_CssSelector = @"div.userContentWrapper";
            }
            // ====
    #region Login and Password
            static string userLogin = "googleplus@gmail.com";
            static string userPassword = "pAAASSSSWWWrd";
    #endregion
            static void Main(string[] args)
            {
                var driver = new FirefoxDriver();
                driver.Url = "https://www.facebook.com";
                // Log-in to Facebook
                var txtLogin    = driver.FindElementByXPath(LoginLocators.txtEmail_XPath);
                var txtPassword = driver.FindElementByXPath(LoginLocators.txtPassword_XPath);
                var btnLogIn    = driver.FindElementByXPath(LoginLocators.btnLogin_XPath);
                txtLogin.SendKeys(userLogin);
                txtPassword.SendKeys(userPassword);
                btnLogIn.Click();
                // Go to F.b. Updates
                driver.Url = "https://www.facebook.com/?sk=nf";
                // Find Elements on Fb. Updates Page
                var txtMessage = driver.FindElementByXPath(PostLocators.txtWhatsOnYourMind_XPath);
                var btnPost = driver.FindElementByXPath(PostLocators.btnPost_XPath);
                
                var userMessagesList = driver.FindElementsByCssSelector(PostLocators.userPostsList_CssSelector);
                int previousMessagesCount = userMessagesList.Count();
                Console.WriteLine("User messages before: {0}", previousMessagesCount);
                string messageGuid = Guid.NewGuid().ToString();
                
                // Perform Post Update
                /* Problem 1: only the following sub text is typed in the status box: 
                 * "date made by test automation using Selenium" */
                txtMessage.SendKeys("Hello! This is an update\n");
                txtMessage.SendKeys("From automated script " + messageGuid);
                btnPost.Click();
                int currentMessagesCount = previousMessagesCount;
                
                /* Problem 2: usually when you post a status, it appears just below 
                 * the status update field. 
                 * How can I identify and confirm it using selenium c#? */
                
                // Wait untill new message is added
                while (currentMessagesCount <= previousMessagesCount)
                {
                    userMessagesList = driver.FindElementsByCssSelector(PostLocators.userPostsList_CssSelector);
                    currentMessagesCount = userMessagesList.Count();
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine("User messages after: {0}", currentMessagesCount);
                // Just for demo purpose :D
                System.Threading.Thread.Sleep(5000);
                            
                driver.Quit();
            }
        }
    }
