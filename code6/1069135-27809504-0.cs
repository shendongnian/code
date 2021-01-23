        [Test]
        public async void TryAuthoriseWithMsLiveLibrary()
        {
            var authClient = new LiveAuthClient(OneNoteApiConfig.ClientID);
            var result = await authClient.InitializeAsync(OneNoteApiConfig.Scopes);
            
            var getLoginUrl = authClient.GetLoginUrl(OneNoteApiConfig.Scopes);
            Console.WriteLine("\r\nGetLoginUrl = " + getLoginUrl);
            // New selenium Driver
            _driver = new FirefoxDriver();
            //Set wait to 2 seconds by defualt
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            // Go to the url provided by auth client
            _driver.Navigate().GoToUrl(getLoginUrl);
            // Try find the accept button, if automatically directed to the "Grant Permission page", otherwise try find the Login/Passwd and login first
            try
            {
                _driver.FindElementById("idBtn_Accept");
            }
            catch (NoSuchElementException)
            {
                var un = _driver.FindElementByName("login"); // Login TextBox
                var pw = _driver.FindElementByName("passwd"); // Password TextBox
                var signIn = _driver.FindElementByName("SI"); // Sign-In Button
                un.SendKeys(OneNoteTestConfig.WindowsLiveUsername);
                pw.SendKeys(OneNoteTestConfig.WindowsLivePassword);
                signIn.Submit();
            }
            // Find a click the idBtn_Accept, if not found straight away, will implictly wait 2 seconds as set baove
            var button = _driver.FindElementById("idBtn_Accept");
            button.Click();
            // Try wait until the client is successfully redirected to the url with the code
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.Url.StartsWith("https://login.live.com/oauth20_desktop.srf"));
                //example https://login.live.com/oauth20_desktop.srf?code=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx&lc=1033
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine(_driver.Url);
                throw;
            }
            
            Console.WriteLine("\r\nUrl = " + _driver.Url);
            // Retrieve code from query string (?code=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx&...)
            var code = MsLiveAuthHelper.GetSessionCodeFromRedirectedUrl(_driver.Url);
            code.Should().NotBeNull();
            Console.WriteLine("\r\ncode = " + code);
            
            // Try get open a session using retrieved code.
            // From my uynderstanding you can only do this once with the code, as it expired after
            // and need to use the refresh token from this point, or re-request a code using above procedure
            var session = await authClient.ExchangeAuthCodeAsync(code);
            session.Should().NotBeNull();
            session.AccessToken.Should().NotBeNullOrWhiteSpace();
            Console.WriteLine("\r\nLiveConnectSession.AccessToken = " + session.AccessToken);
            Console.WriteLine("\r\nLiveConnectSession.AuthenticationToken = " + session.AuthenticationToken);
            Console.WriteLine("\r\nLiveConnectSession.Expires = " + session.Expires);
            Console.WriteLine("\r\nLiveConnectSession.RefreshToken = " + session.RefreshToken);
        }
