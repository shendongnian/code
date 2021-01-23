    ...
    string j = @"{
                ""@size"": ""13"",
                ""text"": ""some text"",
                ""Id"": 483606
            }";
            MyClass mc = Newtonsoft.Json.JsonConvert.DeserializeObject<MyClass>(j);
    ...
    [DataContract]
    public class MyClass
    {
        [DataMember(Name="@size")]
        public string SizeString { get; set; }
        [DataMember()]
        public string text { get; set; }
        [DataMember()]
        public int Id { get; set; }
    }
