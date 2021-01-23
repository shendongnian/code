    public class OAuth1
    {
        const string OAUTH_VERSION = "1.0";
        const string SIGNATURE_METHOD = "HMAC-SHA1";
        const long UNIX_EPOC_TICKS = 621355968000000000L;
        public string GetAuthorizationHeaderString(string method, string url, IDictionary<string, string> parameters, string consumerSecret, string accessTokenSecret)
        {
            string encodedAndSortedString = BuildEncodedSortedString(parameters);
            string signatureBaseString = BuildSignatureBaseString(method, url, encodedAndSortedString);
            string signingKey = BuildSigningKey(consumerSecret, accessTokenSecret);
            string signature = CalculateSignature(signingKey, signatureBaseString);
            string authorizationHeader = BuildAuthorizationHeaderString(encodedAndSortedString, signature);
            return authorizationHeader;
        }  
        internal void AddMissingOAuthParameters(IDictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("oauth_timestamp"))
                parameters.Add("oauth_timestamp", GetTimestamp());
            if (!parameters.ContainsKey("oauth_nonce"))
                parameters.Add("oauth_nonce", GenerateNonce());
            if (!parameters.ContainsKey("oauth_version"))
                parameters.Add("oauth_version", OAUTH_VERSION);
            if (!parameters.ContainsKey("oauth_signature_method"))
                parameters.Add("oauth_signature_method", SIGNATURE_METHOD);     
        }
        internal string BuildEncodedSortedString(IDictionary<string, string> parameters)
        {
            AddMissingOAuthParameters(parameters);
            return
                string.Join("&",
                    (from parm in parameters
                     orderby parm.Key
                     select parm.Key + "=" + PercentEncode(parameters[parm.Key]))
                    .ToArray());
        }
        internal virtual string BuildSignatureBaseString(string method, string url, string encodedStringParameters)
        {
            int paramsIndex = url.IndexOf('?');
            string urlWithoutParams = paramsIndex >= 0 ? url.Substring(0, paramsIndex) : url;
            return string.Join("&", new string[]
            {
                method.ToUpper(),
                PercentEncode(urlWithoutParams),
                PercentEncode(encodedStringParameters)
            });
        }
        internal virtual string BuildSigningKey(string consumerSecret, string accessTokenSecret)
        {
            return string.Format(
                CultureInfo.InvariantCulture, "{0}&{1}", 
                PercentEncode(consumerSecret),
                PercentEncode(accessTokenSecret));
        }
        internal virtual string CalculateSignature(string signingKey, string signatureBaseString)
        {
            byte[] key = Encoding.UTF8.GetBytes(signingKey);
            byte[] msg = Encoding.UTF8.GetBytes(signatureBaseString);
            KeyedHashAlgorithm hasher = new HMACSHA1();
            hasher.Key = key;
            byte[] hash = hasher.ComputeHash(msg);
            return Convert.ToBase64String(hash);
        }
        internal virtual string BuildAuthorizationHeaderString(string encodedAndSortedString, string signature)
        {
            string[] allParms = (encodedAndSortedString + "&oauth_signature=" + PercentEncode(signature)).Split('&');
            string allParmsString =
                string.Join(", ",
                    (from parm in allParms
                     let keyVal = parm.Split('=')
                     where parm.StartsWith("oauth") || parm.StartsWith("x_auth")
                     orderby keyVal[0]
                     select keyVal[0] + "=\"" + keyVal[1] + "\"")
                    .ToList());
            return "OAuth " + allParmsString;
        }
        internal virtual string GetTimestamp()
        {
            long ticksSinceUnixEpoc = DateTime.UtcNow.Ticks - UNIX_EPOC_TICKS;
            double secondsSinceUnixEpoc = new TimeSpan(ticksSinceUnixEpoc).TotalSeconds;
            return Math.Floor(secondsSinceUnixEpoc).ToString(CultureInfo.InvariantCulture);
        }
        internal virtual string GenerateNonce()
        {
            return new Random().Next(111111, 9999999).ToString(CultureInfo.InvariantCulture);
        }
        internal virtual string PercentEncode(string value)
        {
            const string ReservedChars = @"`!@#$^&*()+=,:;'?/|\[] ";
            var result = new StringBuilder();
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            var escapedValue = Uri.EscapeDataString(value);
            // Windows Phone doesn't escape all the ReservedChars properly, so we have to do it manually.
            foreach (char symbol in escapedValue)
            {
                if (ReservedChars.IndexOf(symbol) != -1)
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol).ToUpper());
                }
                else
                {
                    result.Append(symbol);
                }
            }
            return result.ToString();
        }
    }
