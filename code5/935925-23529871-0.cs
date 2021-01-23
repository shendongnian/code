    public class StackOverflow_23529686
    {
        [ServiceContract]
        public class Service
        {
            [OperationContract]
            [WebInvoke(
                Method = "POST",
                BodyStyle = WebMessageBodyStyle.WrappedRequest, 
                RequestFormat = WebMessageFormat.Json)]
            public StatusMessage DoSomeWork(short myId, decimal latitude, decimal longitude, string someData)
            {
                return new StatusMessage
                {
                    Text = string.Format("id={0}, lat={1}, lon={2}, data={3}", myId, latitude, longitude, someData)
                };
            }
        }
        public class StatusMessage
        {
            public string Text { get; set; }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            c.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var json =
                "{'someData':'hello','longitude':-56.78,'latitude':12.34,'myId':1}"
                .Replace('\'', '\"');
            Console.WriteLine(c.UploadString(baseAddress + "/DoSomeWork", json));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
