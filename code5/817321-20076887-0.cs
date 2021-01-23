    public class MyRequest
    {
        [JsonProperty("user")]
        public int User { get; set; }
        [JsonProperty("category")]
        public int Category { get; set; }
        [JsonProperty("itemIds")]
        public IList<string> ItemIds { get; set; }
    }
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_url);
    string password = GetSignatureHash();
    request.Method = "POST";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    request.Headers["Authorization"] = "Basic " + password;
    
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        var myRequest = new MyRequest { User = 1, Category = 1, 
                                        ItemIds = new[] { "1", "2" } };
        
        streamWriter.Write(JsonConvert.SerializeObject(myRequest));
        streamWriter.Flush();
    }
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
