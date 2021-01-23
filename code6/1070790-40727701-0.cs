    private static void verifySites(string username, string password)
    {
         using (var ffox = new FirefoxDriver()
         {
             /// code to login once logged in
             var recaptcha = ffox.FindElementByTagName("iframe");
             recaptcha.Click();
         }
    }
