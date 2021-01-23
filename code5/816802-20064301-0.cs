       public class Service
            {
                [WebInvoke(Method = "PUT", UriTemplate = "Graphs/{library}/{subjectLocalPart}/{predicateLocalPart}/{objectPart}/{languageCode}")]
                public string CreateTriple(string library, string subjectLocalPart, string predicateLocalPart, string objectPart, string languageCode)
                {
                    return string.Format("{0}-{1}-{2}-{3}-{4}", library, subjectLocalPart, predicateLocalPart, objectPart, languageCode);
                }
            }
            public static void Test()
            {
                string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
                WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
                host.Open();
                Console.WriteLine("Host opened");
    
                Console.WriteLine("No '#'");
                Util.SendRequest(baseAddress + "/Graphs/myLib/123abc/content-HasA/456def-ghik/en-us", "PUT", "application/json", "0");
    
                Console.WriteLine("Simple '#' (encoded)");
                Util.SendRequest(baseAddress + "/Graphs/myLib/123abc/content%23HasA/456def%23ghik/en-us", "PUT", "application/json", "0");
    
                Console.WriteLine("Escaped '#'");
                Util.SendRequest(baseAddress + "/Graphs/myLib/123abc/content%2523HasA/456def%2523ghik/en-us", "PUT", "application/json", "0");
    
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
                host.Close();
            }
        }
        public static class Util
        {
            public static string SendRequest(string uri, string method, string contentType, string body)
            {
                string responseBody = null;
    
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
                req.Method = method;
                if (!String.IsNullOrEmpty(contentType))
                {
                    req.ContentType = contentType;
                }
    
                if (body != null)
                {
                    byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                    req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
                    req.GetRequestStream().Close();
                }
    
                HttpWebResponse resp;
                try
                {
                    resp = (HttpWebResponse)req.GetResponse();
                }
                catch (WebException e)
                {
                    resp = (HttpWebResponse)e.Response;
                }
    
                if (resp == null)
                {
                    responseBody = null;
                    Console.WriteLine("Response is null");
                }
                else
                {
                    Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
                    foreach (string headerName in resp.Headers.AllKeys)
                    {
                        Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
                    }
                    Console.WriteLine();
                    Stream respStream = resp.GetResponseStream();
                    if (respStream != null)
                    {
                        responseBody = new StreamReader(respStream).ReadToEnd();
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
                    }
                }
    
                Console.WriteLine();
                Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
                Console.WriteLine();
    
                return responseBody;
            }
