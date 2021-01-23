        private const string DefaultNamespace = "https://yoursbserver:9355/servicebusdefaultnamespace";
        private const string QueueEndpoint = "https://yoursbserver:9355/servicebusdefaultnamespace/YourQueueNameOrTopicName/messages/?timeout=60";
        private static void Main()
        {
            var token = GetOAuthTokenFromSts(new Uri(DefaultNamespace), "usernamewithpermissiononServiceBus", "password", TimeSpan.FromMinutes(10));
            var messageXml = CreateXml();
            SendMessage(token, messageXml);
            Console.WriteLine("Successfully posted message!");
            Console.ReadLine();
        }
        private static string CreateMessage()
        {
            return "<SomeMessage xmlns='MyNamespace'></SomeMessage>";
        }
        public static string GetOAuthTokenFromSts(Uri namespaceBaseAddress, string userName, string userPassword, TimeSpan timeout)
        {
            const string stsPath = "$STS/OAuth/";
            var requestUri = new Uri(namespaceBaseAddress, stsPath);
            var requestContent = GetRequestContent(namespaceBaseAddress, userName, userPassword);
            var request = CreateRequest(timeout, requestUri, requestContent);
            return GetAccessToken(request, requestContent);
        }
        private static HttpWebRequest CreateRequest(TimeSpan timeout, Uri requestUri, byte[] requestContent)
        {
            var request = WebRequest.Create(requestUri) as HttpWebRequest;
            request.ServicePoint.MaxIdleTime = 5000;
            request.AllowAutoRedirect = true;
            request.MaximumAutomaticRedirections = 1;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = requestContent.Length;
            request.Timeout = Convert.ToInt32(timeout.TotalMilliseconds,
                                              CultureInfo.InvariantCulture);
            return request;
        }
        private static byte[] GetRequestContent(Uri namespaceBaseAddress, string userName, string userPassword)
        {
            const string clientPasswordFormat = "grant_type=authorization_code&client_id={0}&client_secret={1}&scope={2}";
            var requestContent = string.Format(CultureInfo.InvariantCulture,
                                                  clientPasswordFormat, HttpUtility.UrlEncode(userName),
                                                  HttpUtility.UrlEncode(userPassword),
                                                  HttpUtility.UrlEncode(namespaceBaseAddress.AbsoluteUri));
            return Encoding.UTF8.GetBytes(requestContent);
        }
        private static string GetAccessToken(HttpWebRequest request, byte[] requestContent)
        {
            string accessToken;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestContent, 0, requestContent.Length);
            }
            using (var response = request.GetResponse() as HttpWebResponse)
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                accessToken = reader.ReadToEnd();
            }
            return string.Format(CultureInfo.InvariantCulture, "WRAP access_token=\"{0}\"", accessToken);
        }
        private static void SendMessage(string token, string message)
        {
            var webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.Authorization] = token;
            webClient.UploadData(QueueEndpoint, "POST", Encoding.UTF8.GetBytes(message));
        }
