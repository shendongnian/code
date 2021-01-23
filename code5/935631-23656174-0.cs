    [XmlRoot("TestDataMap")]
    public class TestDataMap
    {
        public TestDataMap()
        {
            DataMap = new List<BaseItem>();
        }
        
        [XmlArray("DataMap")]
        [XmlArrayItem("ItemBool", typeof("ItemBool"))]
        [XmlArrayItem("ItemInt", typeof("ItemInt"))]
        public List<BaseItem> DataMap { get; set; }
    }
