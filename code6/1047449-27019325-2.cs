    protected void AuthenticateWindowsClassic(string domain, string userName, string password)
            {
                if (userName != null && userName.Length > 0)
                {
                    api.Credentials = new System.Net.NetworkCredential(userName, password, domain);
                }
                else
                {
                    api.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
    
                // Verify set credentials.
                System.Net.NetworkCredential cred = (System.Net.NetworkCredential) api.Credentials;
                Console.WriteLine(@"Credentials set to: {0}\{1}", cred.Domain, cred.UserName);
            }
    
    
    protected bool AuthenticateFBAClaims(string userName, string password)
            {
                FBA.Authentication spAuthentication = new FBA.Authentication();
                spAuthentication.Url = farmURL + "_vti_bin/Authentication.asmx";
                              
                spAuthentication.CookieContainer = new CookieContainer();
    
                FBA.LoginResult loginResult = spAuthentication.Login(userName, password);
                authCookie = new Cookie();
                    
                // Determines if login is successful.
                if (loginResult.ErrorCode == FBA.LoginErrorCode.NoError)
                {
                    // Get the cookie collection from the authenticating Web service.
                    CookieCollection cookies = spAuthentication.CookieContainer.GetCookies(new Uri(spAuthentication.Url));
    
                    // Get the specific cookie that contains the security token.
                    authCookie = cookies[loginResult.CookieName];
    
                    // Initialize the cookie container of Excel Web Services.
                    api.CookieContainer = new CookieContainer();
                    api.CookieContainer.Add(authCookie);
    
                    return true;
                }
                else
                {
                    return false;
                }
         }
