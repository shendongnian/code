    public interface IFilter
    {
        string SomeCommonProp { get; set;}    
    }
    [XmlRoot("myFilter")]
    public class MyFilter : IFilter
    {
        [XmlElement("somemyFilterProp")]
        public string SomeMyFilterProp { get; set; }
    
        [XmlElement("someCommonProp")]
        public string SomeCommonProp { get; set;}
    }
    [XmlRoot("myOtherFilter")]
    public class MyOtherFilter : IFilter
    {
        [XmlElement("someOtherFilterProp")]
        public string SomeOtherFilterProp { get; set; }
        [XmlElement("someCommonProp")]
        public string SomeCommonProp { get; set;}
    }
