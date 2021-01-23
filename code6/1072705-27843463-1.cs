    [XmlRoot(Namespace = "http://example.com")] // NS for root element
    [XmlType(Namespace = "http://example.com/foo")] // NS for the type itself
    public class Foo
    {
        public string Bar { get; set; }
    }
