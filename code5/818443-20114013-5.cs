    [JsonConverter(typeof(DataContainerConverter))]
    public class DataContainer
    {
        public int ID { get; set; }
        public List<Dat> Data { get; set; }
    }
