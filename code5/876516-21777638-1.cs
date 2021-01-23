    public static class MvcExtensions
    {
        /// <summary>
        /// Invokes a request to the specified url and returns the result as an HTML string.
        /// </summary>
        /// <param name="thisHtml">The HTML helper instance that this method extends.</param>
        /// <param name="url">The url to invoke the request on.</param>
        /// <returns>The url contents as an HTML string.</returns>
        public static MvcHtmlString LoadUrl(this HtmlHelper thisHtml, string url)
        {
            //get the url as an absolute url
            UrlHelper helper = GetUrlHelper();
            url = helper.Absolute(url);
            var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            //set the auth cookie so we don't just get the login page
            request.SetAuthenticationCookie();
            //get the response
            string responseString = request.GetResponseString();
            //return it as an html string
            return new MvcHtmlString(responseString);
        }
        private static UrlHelper GetUrlHelper()
        {
            return new UrlHelper(HttpContext.Current.Request.RequestContext);
        }
        /// <summary>
        /// Gets an absolute version of the specified url relative to the current requests url root.
        /// </summary>
        /// <param name="thisHelper">The Url helper instance that this method extends.</param>
        /// <param name="url">The url to get an absolute version of.</param>
        /// <returns>An absolute version of the specified url relative to the current requests url root.</returns>
        public static string Absolute(this UrlHelper thisHelper, string url)
        {
            //only make the url absolute if it isn't already
            if (!url.Contains("://"))
            {
                return string.Format("http://{0}{1}", thisHelper.RequestContext.HttpContext.Request.Url.Authority, thisHelper.Content(url));
            }
            else
            {
                return url;
            }
        }
        /// <summary>
        /// Sets the authentication cookie of the specified request.
        /// </summary>
        /// <param name="request">The request to set the cookie for.</param>
        /// <param name="authenticationCookie">(Optional) The cookie to add to the request, if not specified defaults 
        /// to the cookie of the user currently logged into the site.</param>
        public static void SetAuthenticationCookie(this HttpWebRequest request, Cookie authenticationCookie = null)
        {
            if (authenticationCookie == null)
            {
                //add the current authentication cookie to the request
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                authenticationCookie = new System.Net.Cookie
                (
                    FormsAuthentication.FormsCookieName,
                    cookie.Value,
                    cookie.Path,
                    FormsAuthentication.CookieDomain
                );
            }
            request.CookieContainer = new System.Net.CookieContainer();
            request.CookieContainer.Add(authenticationCookie);
        }
        /// <summary>
        /// Gets the response string from the specified request.
        /// </summary>
        /// <param name="request">The request to get the response string from.</param>
        /// <returns>The response string from the specified request.</returns>
        public static string GetResponseString(this System.Net.WebRequest request)
        {
            System.Net.WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (System.Net.WebException webException)
            {
                response = webException.Response;
                throw;
            }
            return GetResponseString(response);
        }
        /// <summary>
        /// Gets the response string from the specified response.
        /// </summary>
        /// <param name="response">The response to get the response string from.</param>
        /// <returns>The response string from the specified response.</returns>
        public static string GetResponseString(this System.Net.WebResponse response)
        {
            using (var responseTextStream = new System.IO.StreamReader(response.GetResponseStream()))
            {
                return responseTextStream.ReadToEnd();
            }
        }
    }
