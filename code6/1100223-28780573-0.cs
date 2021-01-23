    [XmlRoot("response")]
    public class ResponseWrapper<T>
    {
        [XmlArray("MyObjects")]
        [XmlArrayItem]
        public List<T> Items { get; set; }
        public ResponseWrapper()
        {
        }
        public ResponseWrapper(List<T> items)
        {
            this.Items = items;
        }
    }
