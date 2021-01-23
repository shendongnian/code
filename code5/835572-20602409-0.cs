    namespace ConsoleApplication
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App started");
            var tokenUrl = "http://localhost:29825/token";
            var userName = "stack";
            var userPassword = "password";
            var request = string.Format("grant_type=password&username={0}&password={1}", HttpUtility.UrlEncode(userName), HttpUtility.UrlEncode(userPassword));
            var token = HttpPost(tokenUrl, request);
            var url = "http://localhost:29825/api/clients";
            var clients =  HttpGet(url, token.access_token);
            foreach (var client in clients)
            {
                Console.WriteLine(client.Name);
            }
            
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();
        }
        private static AccessToken HttpPost(string tokenUrl, string requestDetails)
        {
            WebRequest webRequest = WebRequest.Create(tokenUrl);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccessToken));
                AccessToken token = (AccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
        private static List<Client> HttpGet(string url, string token)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Bearer " + token);
            
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Client>));
                List<Client> clients = (List<Client>)serializer.ReadObject(webResponse.GetResponseStream());
                return clients;
            }
        }
        [DataContract]
        public class AccessToken
        {
            [DataMember]
            public string access_token { get; set; }
            [DataMember]
            public string token_type { get; set; }
            [DataMember]
            public string expires_in { get; set; }
            [DataMember]
            public string userName { get; set; }
        }
        [DataContract]
        public class Client
        {
            [DataMember]
            public string Id { get; set; }
            [DataMember]
            public string Name { get; set; }
        }
    }
}
