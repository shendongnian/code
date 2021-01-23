    var obj = new ApiToken();
    obj.setApiKey("X-X-X");
    obj.setI(666);
    var settings = new Newtonsoft.Json.JsonSerializerSettings() { 
                         ContractResolver = new MyContractResolver() 
                   };
    var json = JsonConvert.SerializeObject(obj, settings);
    //json : {"ApiKey":"X-X-X","I":666}
    var newobj = JsonConvert.DeserializeObject<ApiToken>(json, settings);
------
    //Test class
    public class ApiToken 
    {
        private String apiKey;
        public String getApiKey()
        {
            return apiKey;
        }
        public void setApiKey(String apiKey)
        {
            this.apiKey = apiKey;
        }
        private int i;
        public int getI()
        {
            return i;
        }
        public void setI(int i)
        {
            this.i = i;
        }
        public string dummy()
        {
            return "abcde";
        }
    }
