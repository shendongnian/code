    public class MainClass<T>
    {
        [JsonProperty("status")]
        public Statuses Status { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        
        public static MainClass<T> Parse(string mainClsTxt)
        {
            var response = JsonConvert.DeserializeObject<MainClass<T>>(mainClsTxt);
            return response;
            
        }
    } 
