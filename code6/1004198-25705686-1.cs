    async void TestRestService()
    {
        var ready = new TaskCompletionSource<object>();
        Task.Factory.StartNew(() =>
        {
            var uri = new Uri("http://0.0.0.0:49452/Metrics.svc/");
            var type = typeof(Metrics);
            WebServiceHost host = new WebServiceHost(type, uri);
            host.Open();
            ready.SetResult(null);
        },TaskCreationOptions.LongRunning);
        await ready.Task;
        var customObject = new CustomClass() { Name = "John", Id = 333 };
        var serialized = JsonConvert.SerializeObject(new { obj = customObject });
        var httpClient = new HttpClient();
        var request = new StringContent(serialized,Encoding.UTF8,"application/json");
        var response = await httpClient.PostAsync("http://localhost:49452/Metrics.svc/LogStartup", request);
        string content = await response.Content.ReadAsStringAsync();
    }
    [ServiceContract]
    public class Metrics
    {
        [OperationContract]
        [WebInvoke(Method = "POST",  BodyStyle = WebMessageBodyStyle.Wrapped)]
        public string LogStartup(CustomClass obj)
        {
            return obj.Name + "=>" + obj.Id;
        }
    }
    public class CustomClass
    {
        public string Name { set; get; }
        public int Id { set; get; }
    }
