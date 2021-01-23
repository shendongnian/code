    [XmlRoot(Name="FooElement", Namespace = "http://example.com")] // NS for root element
    [XmlType(Name="FooType", Namespace = "http://example.com/foo")] // NS for the type itself
    public class Foo
    {
        public string Bar { get; set; }
    }
