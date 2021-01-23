        [TestMethod]
        public void LoginTest()
        {
            var loginForm = driver.FindElementByXPath("//form[@id='login-form']");
            if (loginForm.Enabled)
            {
                MainPageLogin(loginForm);
                CheckLoginForm();
            }
            else
            {
                CheckLoginForm();
            }
            **Thread.Sleep(5000);**
            Assert.AreEqual(driver.Url, "https://staging.mytigo.com/en/");
        }
