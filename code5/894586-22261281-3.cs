    private static void Main(string[] args)
        {
            Remote remote = new Remote(endPoint, methodType, methodName, methodData);
            string requestUri = remote.GetEndPoint() + remote.GetMethodName() + remote.GetDataPost();
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = remote.GetMethodType();
            request.ContentLength = 0;
            request.ContentType = "text/xml";
            Console.WriteLine("Wait until the WebService starts and then press a key to continue!");
            Console.ReadKey();
            try
            {
                var response = request.GetResponse();
                Stream getResponseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(getResponseStream);
                string friendlyResponse = GenerateFriendlyJson(sr.ReadToEnd());
                var jss = new JavaScriptSerializer();
                var product = jss.Deserialize<Dictionary<string, string>>(friendlyResponse);
                Console.WriteLine("Name: " + product["Name"] +
                                ", Description: " + product["Description"] +
                                ", Price: " + product["Price"] +
                                ", Quantity: " + product["Quantity"]);
            }
            catch (WebException wEx)
            {
                Console.WriteLine("Could not access to network through protocol: \n" + wEx.ToString());
            }
            catch (Exception cEx)
            {
                Console.WriteLine("Some common excepion happened: \n" + cEx.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
