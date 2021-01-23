    public class Connection
    {
        public string PS { get; set; }
        public string pr { get; set; }
    }
    
    public class Params
    {
        public string Action { get; set; }
        public int ID { get; set; }
        public string Dlr { get; set; }
    }
    
    public class Execute
    {
        public Execute()
        {
            this.Parameters = new Params();
        }
    
        public string name { get; set; }
        
        [JsonProperty("params")]
        public Params Parameters { get; set; }
    }
    
    public class Request
    {
        public Request()
        {
            this.connection = new Connection();
            this.execute = new Execute();
        }
    
        public Connection connection { get; set; }
        public Execute execute { get; set; }
    }
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        var request = new Request();
    
        /* Set other properties as well */
        request.execute.Parameters.ID = 172024;
        string json = JsonConvert.SerializeObject(request);
        streamWriter.Write(json);
    }
