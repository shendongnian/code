    [DataContract]
    public class RootObject
    {
        public RootObject()
        {
            this.ResultList = new List<Item>();
        }
        [DataMember(Name="results")]
        [JsonConverter(typeof(DeletetedItemSkippingCollectionConverter<Item>))]
        public List<Item> ResultList { get; set; }
    }
