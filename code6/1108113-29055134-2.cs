        class TestWebRequestCreate : IWebRequestCreate
        {
            static WebRequest _nextRequest;
            static readonly object LockObject = new object();
            static public WebRequest NextRequest
            {
                get { return _nextRequest; }
                set
                {
                    lock (LockObject)
                    {
                        _nextRequest = value;
                    }
                }
            }
            public WebRequest Create(Uri uri)
            {
                return _nextRequest;
            }
            public static WebRequest CreateTestRequest(string response)
            {
                var request = MockRepository.GeneratePartialMock<WebRequest>();
                CreateTestWebRequest(request, response);
                NextRequest = request;
                return request;
            }
            private static void CreateTestWebRequest(WebRequest request, string responseStr)
            {
                var requestStream = new MemoryStream();
                request.Stub(x => x.GetRequestStream()).Return(requestStream);
                request.Stub(x => x.Method).PropertyBehavior();
                request.Stub(x => x.ContentType).PropertyBehavior();
                request.Stub(x => x.ContentLength).PropertyBehavior();
                var response = CreateTestWebResponse(responseStr);
                request.Stub(x => x.GetResponse()).Return(response);
            }
            private static WebResponse CreateTestWebResponse(string responseStr)
            {
                var response = MockRepository.GeneratePartialMock<HttpWebResponse>();
                var responseStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseStr));
                response.Stub(x => x.GetResponseStream()).Return(responseStream);
                return response;
            }
        }
