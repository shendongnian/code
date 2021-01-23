            List<string> strings = null;
            // Using Custom Bindings to allow Fiddler to see the HTTP interchange.
            BasicHttpBinding binding = new BasicHttpBinding();            
            binding.AllowCookies = true;
            binding.BypassProxyOnLocal = false;
            binding.ProxyAddress = new Uri("http://127.0.0.1:8888");
            binding.UseDefaultWebProxy = false;
            EndpointAddress url = new EndpointAddress("http://192.168.20.4:42312/Classes/TestService.svc");
            using (TestServiceClient client = new TestServiceClient(binding,url))
            {                
                using (new OperationContextScope(client.InnerChannel))
                {
                    strings = new List<string>(client.WSResult());
                    HttpResponseMessageProperty response = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
                    CookieCollection cookies = new CookieCollection();
                    foreach (string str in response.Headers["Set-Cookie"].ToString().Split(";".ToCharArray()))
                    {
                        Cookie cookie = new Cookie(str.Split("=".ToCharArray())[0].Trim(), str.Split("=".ToCharArray())[1].Trim());
                        cookies.Add(cookie);
                    }
                }
                
            } 
