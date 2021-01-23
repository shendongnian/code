    public class FileInformation
    {
        public string name{get;set;}
        [JsonProperty(PropertyName = "mime-type")]
        public string mimeType{get;set;}
        public int size {get;set;}
    }
