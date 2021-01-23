    public class SPRestExecutor
    {
        public SPRestExecutor(Uri webUri,string accessToken)
        {
            WebUri = webUri;
            AccessToken = accessToken;
        }
        public JObject ExecuteJsonWithDigest(string endpointUrl, HttpMethod method, IDictionary<string, string> headers, JObject payload)
        {
            var formDigestValue = RequestFormDigest();
            var finalHeaders = new Dictionary<string, string>();
            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    finalHeaders.Add(key, headers[key]);
                }
            }
            finalHeaders.Add("X-RequestDigest", formDigestValue);
            var result = ExecuteJson(endpointUrl, method, finalHeaders, payload);
            return result;
        }
        public JObject ExecuteJson(string endpointUrl, HttpMethod method, IDictionary<string, string> headers, JObject payload)
        {
            var request = (HttpWebRequest)WebRequest.Create(WebUri.ToString() + endpointUrl);
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AccessToken);
            request.Method = method.Method;
            request.Accept = "application/json;odata=verbose";
            request.ContentType = "application/json;odata=verbose";
            if (payload != null)
            {
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(payload);
                    writer.Flush();
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using(var responseStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        var result = reader.ReadToEnd();
                        return JObject.Parse(result);
                    }
                }
            }
        }
        /// <summary>
        /// Request Form Digest
        /// </summary>
        /// <returns></returns>
        protected string RequestFormDigest()
        {
            var result = ExecuteJson("/_api/contextinfo", HttpMethod.Post, null, null);
            return result["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
        }
        public string AccessToken { get; private set; }
        public Uri WebUri { get; private set; }
    }
