    public class RequestPrivilege
    {
        [JsonProperty("Fachr")]
        public string Fachr { get; set; }
    
        [JsonProperty("PrivId")]
        public string PrivId { get; set; }
    }
    
    [HttpPost]
    public string RequestPrivilege(string allRequests)
    {  
        [...]
        List<RequestPrivilege> allRequestsObj = JsonConvert.DeserializeObject<List<RequestPrivilege>>(allRequests);
        [...]
    }
