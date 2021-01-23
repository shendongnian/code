    using Pokemon.BL.Utils;
    using System;
    using System.Text;
    using System.Web;
    
    namespace Pokemon.BL
    {
        sealed class UrlFetcher : IDisposable
        {
            private static readonly UrlFetcher _instance;
            private CGWebClient _cgWebClient;
    
            private string loginPostString = "__EVENTTARGET={0}&__EVENTARGUMENT={1}&__VIEWSTATE={2}&__VIEWSTATEGENERATOR={3}&__EVENTVALIDATION={4}&ctl00$MainContent$Email={5}&ctl00$MainContent$Password={6}&ctl00$MainContent$ctl05={7}";
            private string secretPhrasePostString = "__EVENTTARGET={0}&__EVENTARGUMENT={1}&__VIEWSTATE={2}&__VIEWSTATEGENERATOR={3}&__EVENTVALIDATION={4}&__ASYNCPOST=true&ctl00$MainContent$btnGetSecretPhrase=Button&ctl00$ctl08=ctl00$MainContent$UpdatePanel1|ctl00$MainContent$btnGetSecretPhrase&ctl00$MainContent$txtSecret={5}";
    
            private UrlFetcher()
            {
                _cgWebClient = new CGWebClient();
            }
    
            static UrlFetcher()
            {
                _instance = new UrlFetcher();
            }
    
            #region Methods
    
            public void LoginToSite(string email, string password)
            {
                var loginUrl = "http://localhost:53998/Account/Login";
                
                byte[] response = _cgWebClient.DownloadData(loginUrl);
                var content = Encoding.UTF8.GetString(response);
    
                string eventTarget = ExtractToken("__EVENTTARGET", content);
                string eventArg = ExtractToken("__EVENTARGUMENT", content);
                string viewState = ExtractToken("__VIEWSTATE", content);
                string viewStateGen = ExtractToken("__VIEWSTATEGENERATOR", content);
                string eventValidation = ExtractToken("__EVENTVALIDATION", content);
    
                string postData = string.Format(
                    loginPostString,
                    eventTarget,
                    eventArg,
                    viewState, 
                    viewStateGen, 
                    eventValidation,
                    email, 
                    password,
                    "Log in"
                    );
    
                _cgWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                response = _cgWebClient.UploadData(loginUrl, "POST", Encoding.UTF8.GetBytes(postData));
                _cgWebClient.Headers.Remove("Content-Type");
            }
     
            public void GetSecretPhrase()
            {
                var loginUrl = "http://localhost:53998/Account/Manage";
    
                byte[] response = _cgWebClient.DownloadData(loginUrl);
                var content = Encoding.UTF8.GetString(response);
    
                string eventTarget = ExtractToken("__EVENTTARGET", content);
                string eventArg = ExtractToken("__EVENTARGUMENT", content);
                string viewState = ExtractToken("__VIEWSTATE", content);
                string viewStateGen = ExtractToken("__VIEWSTATEGENERATOR", content);
                string eventValidation = ExtractToken("__EVENTVALIDATION", content);
    
                string postData = string.Format(
                    secretPhrasePostString,
                    eventTarget,
                    eventArg,
                    viewState,
                    viewStateGen,
                    eventValidation,
                    "secret"
                    );
    
                _cgWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                _cgWebClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
                response = _cgWebClient.UploadData(loginUrl, "POST", Encoding.UTF8.GetBytes(postData));
                _cgWebClient.Headers.Remove("Content-Type");
                _cgWebClient.Headers.Remove("X-Requested-With");
    
                Console.WriteLine(Encoding.UTF8.GetString(response));
            }
    
            #region IDisposable Members
            public void Dispose()
            {
                if (_cgWebClient != null)
                {
                    _cgWebClient.Dispose();
                }
            }
            #endregion
    
            private string ExtractToken(string whatToExtract, string content)
            {
                string viewStateNameDelimiter = whatToExtract;
                string valueDelimiter = "value=\"";
    
                int viewStateNamePosition = content.IndexOf(viewStateNameDelimiter);
                int viewStateValuePosition = content.IndexOf(valueDelimiter, viewStateNamePosition);
    
                int viewStateStartPosition = viewStateValuePosition + valueDelimiter.Length;
                int viewStateEndPosition = content.IndexOf("\"", viewStateStartPosition);
    
                return HttpUtility.UrlEncode(
                         content.Substring(
                            viewStateStartPosition,
                            viewStateEndPosition - viewStateStartPosition
                         )
                      );
            }
            #endregion
    
            #region Properties
            public static UrlFetcher Instance { get { return _instance; } }
            #endregion
        }
    }
    
