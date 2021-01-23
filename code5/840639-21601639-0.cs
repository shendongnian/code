    public static class OauthHelper
    {
        public const string ConsumerKey = "MyKey";
        public const string ConsumerSecret = "MySecret";
        public const string UriScheme = "https";
        public const string HostName = "api.somePlace.com";
        public const string RequestPath = "/services/api/json/1.3.0";
        public const string OauthSignatureMethod = "HMAC-SHA1";
        public const string OauthVersion = "1.0";
        public static string BuildRequestUri(Dictionary<string, string> requestParameters)
        {
            var url = GetNormalizedUrl(UriScheme, HostName, RequestPath);
            var allParameters = new List<QueryParameter>(requestParameters.Select(entry => new QueryParameter(entry.Key, entry.Value)));
            var normalizedParameters = NormalizeParameters(allParameters);
            var requestUri = string.Format("{0}?{1}", url, normalizedParameters);
            return requestUri;
        }
        public static AuthenticationHeaderValue CreateAuthorizationHeader(
            string oauthToken,
            string oauthNonce,
            string oauthTimestamp,
            string oauthSignature)
        {
            var normalizedUrl = GetNormalizedUrl(UriScheme, HostName, RequestPath);
            return CreateAuthorizationHeader(oauthToken, oauthNonce, oauthTimestamp, oauthSignature, normalizedUrl);
        }
        public static AuthenticationHeaderValue CreateAuthorizationHeader(
            string oauthToken,
            string oauthNonce,
            string oauthTimestamp,
            string oauthSignature,
            string realm)
        {
            if (string.IsNullOrWhiteSpace(oauthToken))
            {
                oauthToken = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(oauthTimestamp))
            {
                throw new ArgumentNullException("oauthTimestamp");
            }
            if (string.IsNullOrWhiteSpace(oauthNonce))
            {
                throw new ArgumentNullException("oauthNonce");
            }
            if (string.IsNullOrWhiteSpace(oauthSignature))
            {
                throw new ArgumentNullException("oauthSignature");
            }
            var authHeaderValue = string.Format(
                "realm=\"{0}\"," +
                "oauth_consumer_key=\"{1}\"," +
                "oauth_token=\"{2}\"," +
                "oauth_nonce=\"{3}\"," +
                "oauth_timestamp=\"{4}\"," +
                "oauth_signature_method=\"{5}\"," +
                "oauth_version=\"{6}\"," +
                "oauth_signature=\"{7}\"",
                realm,
                Uri.EscapeDataString(ConsumerKey),
                Uri.EscapeDataString(oauthToken),
                Uri.EscapeDataString(oauthNonce),
                Uri.EscapeDataString(oauthTimestamp),
                Uri.EscapeDataString(OauthSignatureMethod),
                Uri.EscapeDataString(OauthVersion),
                Uri.EscapeDataString(oauthSignature));
            var authHeader = new AuthenticationHeaderValue("OAuth", authHeaderValue);
            return authHeader;
        }
        public static string CreateSignature(
            string httpMethod,
            string oauthToken,
            string oauthTokenSecret,
            string oauthTimestamp,
            string oauthNonce,
            Dictionary<string, string> requestParameters)
        {
            // get normalized url
            var normalizedUrl = GetNormalizedUrl(UriScheme, HostName, RequestPath);
            return CreateSignature(
                httpMethod,
                oauthToken,
                oauthTokenSecret,
                oauthTimestamp,
                oauthNonce,
                requestParameters,
                normalizedUrl);
        }
        public static string CreateSignature(
            string httpMethod,
            string oauthToken,
            string oauthTokenSecret,
            string oauthTimestamp,
            string oauthNonce,
            Dictionary<string, string> requestParameters,
            string realm)
        {
            if (string.IsNullOrWhiteSpace(httpMethod))
            {
                throw new ArgumentNullException("httpMethod");
            }
            if (string.IsNullOrWhiteSpace(oauthToken))
            {
                oauthToken = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(oauthTokenSecret))
            {
                oauthTokenSecret = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(oauthTimestamp))
            {
                throw new ArgumentNullException("oauthTimestamp");
            }
            if (string.IsNullOrWhiteSpace(oauthNonce))
            {
                throw new ArgumentNullException("oauthNonce");
            }
            var allParameters = new List<QueryParameter>
            {
                new QueryParameter("oauth_consumer_key", ConsumerKey),
                new QueryParameter("oauth_token", oauthToken),
                new QueryParameter("oauth_nonce", oauthNonce),
                new QueryParameter("oauth_timestamp", oauthTimestamp),
                new QueryParameter("oauth_signature_method", OauthSignatureMethod),
                new QueryParameter("oauth_version", OauthVersion)
            };
            allParameters.AddRange(requestParameters.Select(entry => new QueryParameter(entry.Key, entry.Value)));
            // sort params
            allParameters.Sort(new QueryParameterComparer());
            // concat all params
            var normalizedRequestParameters = NormalizeParameters(allParameters);
            // create base string
            var signatureBase = string.Format(
                "{0}&{1}&{2}",
                UrlEncode(httpMethod.ToUpperInvariant()),
                UrlEncode(realm),
                UrlEncode(normalizedRequestParameters));
            var signatureKey = string.Format(
                "{0}&{1}",
                UrlEncode(ConsumerSecret),
                UrlEncode(oauthTokenSecret));
            // hash the base string
            var hmacsha1 = new HMACSHA1(StringToAscii(signatureKey));
            var signatureString = Convert.ToBase64String(hmacsha1.ComputeHash(StringToAscii(signatureBase)));
            return signatureString;
        }
        public static string GenerateNonce()
        {
            var ts = new TimeSpan(DateTime.Now.Ticks);
            var ms = ts.TotalMilliseconds.ToString().Replace(".", string.Empty);
            var nonce = ms;
            return nonce;
        }
        public static string GenerateTimeStamp()
        {
            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            var timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString(CultureInfo.InvariantCulture);
            return timestamp;
        }
        private static string GetNormalizedUrl(string uriScheme, string hostName, string requestPath)
        {
            var normalizedUrl = string.Format(
                "{0}://{1}{2}",
                uriScheme.ToLowerInvariant(),
                hostName.ToLowerInvariant(),
                requestPath);
            return normalizedUrl;
        }
        private static string NormalizeParameters(IList<QueryParameter> parameters)
        {
            var result = new StringBuilder();
            for (var i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];
                result.AppendFormat("{0}={1}", p.Name, p.Value);
                if (i < parameters.Count - 1)
                {
                    result.Append("&");
                }
            }
            return result.ToString();
        }
        private static byte[] StringToAscii(string s)
        {
            var retval = new byte[s.Length];
            for (var ix = 0; ix < s.Length; ++ix)
            {
                var ch = s[ix];
                if (ch <= 0x7f)
                {
                    retval[ix] = (byte)ch;
                }
                else
                {
                    retval[ix] = (byte)'?';
                }
            }
            return retval;
        }
        private static string UrlEncode(string value)
        {
            const string Unreserved = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var result = new StringBuilder();
            foreach (char symbol in value)
            {
                if (Unreserved.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + string.Format("{0:X2}", (int)symbol));
                }
            }
            return result.ToString();
        }
    }
    public class QueryParameter
    {
        public QueryParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }
    }
    public class QueryParameterComparer : IComparer<QueryParameter>
    {
        public int Compare(QueryParameter x, QueryParameter y)
        {
            return x.Name == y.Name
                ? string.Compare(x.Value, y.Value)
                : string.Compare(x.Name, y.Name);
        }
    }
