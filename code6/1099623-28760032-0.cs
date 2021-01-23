    public class MyJsonValueClass
    {
        [JsonProperty(PropertyName = "ID")]
        public int Productid { get; set; }
    
        [JsonProperty(PropertyName = "ProductName ")] 
        public string Name { get; set; }
    }
    List<MyJsonValueClass> jsonData = JsonConvert.DeserializeObject<List<MyJsonValueClass>(json);
