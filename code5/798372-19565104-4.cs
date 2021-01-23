    [BsonDiscriminator("Abusiness")] // provide discriminator value here
    public class AsubBusiness : SubBusiness
    {
        [BsonElement("a")]
        public string A { get; set; }
    }
    [BsonDiscriminator("Bbusiness")]
    public class BsubBusiness : SubBusiness
    {
        [BsonElement("b")]
        public string B { get; set; }
        [BsonElement("c")]
        public string C { get; set; }
    }
