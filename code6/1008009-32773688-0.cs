    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using WatiN.Core.Native;
    using WatiN.Core;
    namespace LouiesOAuthCodeGrantFlow
    {
        // Using access tokens requires that you register your application and that
        // the user gives consent to your application to access their data. This 
        // example uses a form and WebBrowser control to get the user's consent.
        // The control and form require a single-threaded apartment.
    partial class LouiesBingOAuthAutomation 
    {
        private static LouiesBingOAuthAutomation _form;
        private static string _code;
        private static string _error;
        //your going to want to put these in a secure place this is for the sample
        public const string UserName = "your microsoft user name";
        public const string Password = "<your microsoft account password";
        // When you register your application, the Client ID is provisioned.
        //get your clientid https://developers.bingads.microsoft.com/Account
        private const string ClientId = "<your client id>";
        // Request-related URIs that you use to get an authorization code, 
        // access token, and refresh token.
        private const string AuthorizeUri = "https://login.live.com/oauth20_authorize.srf";
        private const string TokenUri = "https://login.live.com/oauth20_token.srf";
        private const string DesktopUri = "https://login.live.com/oauth20_desktop.srf";
        private const string RedirectPath = "/oauth20_desktop.srf";
        private const string ConsentUriFormatter = "{0}?client_id={1}&scope=bingads.manage&response_type=code&redirect_uri={2}";//&displayNone
        private const string AccessUriFormatter = "{0}?client_id={1}&code={2}&grant_type=authorization_code&redirect_uri={3}";
        private const string RefreshUriFormatter = "{0}?client_id={1}&grant_type=refresh_token&redirect_uri={2}&refresh_token={3}";
        // Constructor
        public LouiesBingOAuthAutomation(string uri)
        {
            InitializeForm(uri);
        }
        [STAThread]
        static void Main()
        {
            var uri = string.Format(ConsentUriFormatter, AuthorizeUri, ClientId, DesktopUri);
            _form = new LouiesBingOAuthAutomation(uri);
            if (string.IsNullOrEmpty(_code))
            {
                Console.WriteLine(_error);
                return;
            }
            uri = string.Format(AccessUriFormatter, TokenUri, ClientId, _code, DesktopUri);
            AccessTokens tokens = GetAccessTokens(uri);
            Console.WriteLine("Access token expires in {0} minutes: ", tokens.ExpiresIn / 60);
            Console.WriteLine("\nAccess token: " + tokens.AccessToken);
            Console.WriteLine("\nRefresh token: " + tokens.RefreshToken);
            uri = string.Format(RefreshUriFormatter, TokenUri, ClientId, DesktopUri, tokens.RefreshToken);
            tokens = GetAccessTokens(uri);
            Console.WriteLine("Access token expires in {0} minutes: ", tokens.ExpiresIn / 60);
            Console.WriteLine("\nAccess token: " + tokens.AccessToken);
            Console.WriteLine("\nRefresh token: " + tokens.RefreshToken);
        }
        private void InitializeForm(string uri)
        {
            using (var browser = new IE(uri))
            {
                var page = browser.Page<MyPage>();
                page.PasswordField.TypeText(Password);
                try
                {
                    StringBuilder js = new StringBuilder();
                    js.Append(@"var myTextField = document.getElementById('i0116');");
                    js.Append(@"myTextField.setAttribute('value', '"+ UserName + "');");
                    browser.RunScript(js.ToString());
                    var field = browser.ElementOfType<TextFieldExtended>("i0116");
                    field.TypeText(UserName);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message + ex.StackTrace);
                }
                page.LoginButton.Click();
                browser.WaitForComplete();
                browser.Button(Find.ById("idBtn_Accept")).Click();
                var len = browser.Url.Length - 43;
                string query = browser.Url.Substring(43, len);
                if (query.Length == 50)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        Dictionary<string, string> parameters = ParseQueryString(query, new[] { '&', '?' });
                        if (parameters.ContainsKey("code"))
                        {
                            _code = parameters["code"];
                        }
                        else
                        {
                            _error = Uri.UnescapeDataString(parameters["error_description"]);
                        }
                    }
                }
            }
          
        }
        // Parses the URI query string. The query string contains a list of name-value pairs 
        // following the '?'. Each name-value pair is separated by an '&'.
        private static Dictionary<string, string> ParseQueryString(string query, char[] delimiters)
        {
            var parameters = new Dictionary<string, string>();
            string[] pairs = query.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string pair in pairs)
            {
                string[] nameValue = pair.Split(new[] { '=' });
                parameters.Add(nameValue[0], nameValue[1]);
            }
            return parameters;
        }
        // Gets an access token. Returns the access token, access token 
        // expiration, and refresh token.
        private static AccessTokens GetAccessTokens(string uri)
        {
            var responseSerializer = new DataContractJsonSerializer(typeof(AccessTokens));
            AccessTokens tokenResponse = null;
            try
            {
                var realUri = new Uri(uri, UriKind.Absolute);
                var addy = realUri.AbsoluteUri.Substring(0, realUri.AbsoluteUri.Length - realUri.Query.Length);
                var request = (HttpWebRequest)WebRequest.Create(addy);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(realUri.Query.Substring(1));
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        tokenResponse = (AccessTokens)responseSerializer.ReadObject(responseStream);
                }
            }
            catch (WebException e)
            {
                var response = (HttpWebResponse)e.Response;
                Console.WriteLine("HTTP status code: " + response.StatusCode);
            }
            return tokenResponse;
        }
     }
     public class MyPage : WatiN.Core.Page
     {
        public TextField PasswordField
        {
            get { return Document.TextField(Find.ByName("passwd")); }
        }
        public WatiN.Core.Button LoginButton
        {
            get { return Document.Button(Find.ById("idSIButton9")); }
        }
     }
     [ElementTag("input", InputType = "text", Index = 0)]
     [ElementTag("input", InputType = "password", Index = 1)]
     [ElementTag("input", InputType = "textarea", Index = 2)]
     [ElementTag("input", InputType = "hidden", Index = 3)]
     [ElementTag("textarea", Index = 4)]
     [ElementTag("input", InputType = "email", Index = 5)]
     [ElementTag("input", InputType = "url", Index = 6)]
     [ElementTag("input", InputType = "number", Index = 7)]
     [ElementTag("input", InputType = "range", Index = 8)]
     [ElementTag("input", InputType = "search", Index = 9)]
     [ElementTag("input", InputType = "color", Index = 10)]
     public class TextFieldExtended : TextField
     {
        public TextFieldExtended(DomContainer domContainer, INativeElement element)
            : base(domContainer, element)
        {
        }
        public TextFieldExtended(DomContainer domContainer, ElementFinder finder)
            : base(domContainer, finder)
        {
        }
        public static void Register()
        {
            Type typeToRegister = typeof(TextFieldExtended);
            ElementFactory.RegisterElementType(typeToRegister);
        }
     }
     // The grant flow returns more fields than captured in this sample.
     // Additional fields are not relevant for calling Bing Ads APIs or refreshing the token.
     [DataContract]
     class AccessTokens
     {
        [DataMember]
        // Indicates the duration in seconds until the access token will expire.
        internal int expires_in = 0;
        [DataMember]
        // When calling Bing Ads service operations, the access token is used as  
        // the AuthenticationToken header element.
        internal string access_token = null;
        [DataMember]
        // May be used to get a new access token with a fresh expiration duration.
        internal string refresh_token = null;
        public string AccessToken { get { return access_token; } }
        public int ExpiresIn { get { return expires_in; } }
        public string RefreshToken { get { return refresh_token; } }
     }
    }
