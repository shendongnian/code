    string json = @"{
                ""dc:creator"":""Jordan, Micheal"",
                ""element:publicationName"":""Applied Ergonomics"",
                ""element:issn"":""2839749823""
            }";
    var pub = JsonConvert.DeserializeObject<Publication>(json);
----
    public class Publication
    {
        [JsonProperty("dc:creator")]
        public string creator { set; get; }
        [JsonProperty("element:publicationName")]
        public string publicationName { set; get; }
        [JsonProperty("element:issn")]
        public string issn { set; get; }
    }
