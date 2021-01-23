         using System.ServiceModel.Dispatcher;
        using System.ServiceModel.Description;
      public class StackOverflow_6783264
    {
     public class InputData
    {
        public string FirstName;
        public string LastName;
    }
    [ServiceContract]
    public interface ITest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/InsertData?param1={param1}")]
        string saveDataGet(InputData param1);
        [OperationContract]
        [WebInvoke(UriTemplate = "/InsertData")]
        string saveDataPost(InputData param1);
    }
    public class Service : ITest
    {
        public string saveDataGet(InputData param1)
        {
            return "Via GET: " + param1.FirstName + " " + param1.LastName;
        }
        public string saveDataPost(InputData param1)
        {
            return "Via POST: " + param1.FirstName + " " + param1.LastName;
        }
    }
    public class MyQueryStringConverter : QueryStringConverter
    {
        public override bool CanConvert(Type type)
        {
            return (type == typeof(InputData)) || base.CanConvert(type);
        }
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            if (parameterType == typeof(InputData))
            {
                string[] parts = parameter.Split(',');
                return new InputData { FirstName = parts[0], LastName = parts[1] };
            }
            else
            {
                return base.ConvertStringToValue(parameter, parameterType);
            }
        }
    }
    public class MyWebHttpBehavior : WebHttpBehavior
    {
        protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
        {
            return new MyQueryStringConverter();
        }
    }
    public static void Test()
    {
        string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
        ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
        host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "").Behaviors.Add(new MyWebHttpBehavior());
        host.Open();
        Console.WriteLine("Host opened");
        WebClient client = new WebClient();
        Console.WriteLine(client.DownloadString(baseAddress + "/InsertData?param1=John,Doe"));
        client = new WebClient();
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        Console.WriteLine(client.UploadString(baseAddress + "/InsertData", "{\"FirstName\":\"John\",\"LastName\":\"Doe\"}"));
        Console.Write("Press ENTER to close the host");
        Console.ReadLine();
        host.Close();
     }
  
}
