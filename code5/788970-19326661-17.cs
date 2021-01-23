    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    public class Product
    {
        [DataMember]
        public Image MainImage { get; set; }
        [DataMember]
        public List<Image> AllImages { get; set; }
    }
    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    public class Image
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Url { get; set; }
    }
