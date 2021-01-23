    public class ResponseObject
    {
        public string next_page { get; set; }
    }
    
    var responseResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>(response);
