    For instance, simplifying your `RootXml` class somewhat, the following allows for two different types of report to be serialized:
        [XmlRoot("Report", Namespace = "")]
        public class Report
        {
            [XmlAttribute]
            public string Code { get; set; }
            [XmlElement]
            public decimal TotalCost { get; set; }
        }
        [XmlRoot("DifferentReport", Namespace = "")]
        public class DifferentReport
        {
            [XmlAttribute]
            public string Code { get; set; }
            [XmlText]
            public string Value { get; set; }
        }
        [XmlRoot("RootXml", Namespace = "")]
        public class RootXml
        {
            public RootXml() { }
            object _test;
            [XmlElement("Report", Type=typeof(Report))]
            [XmlElement("DifferentReport", Type = typeof(DifferentReport))]
            public object Data
            {
                get { return _test; }
                set { _test = value; }
            }
        }
    And then later, both of the following can be serialized and deserialized:
            var root1 = new RootXml { Data = new Report { Code = "a code", TotalCost = (decimal)101.01 } };
            var root2 = new RootXml { Data = new DifferentReport { Code = "a different code", Value = "This is the value of the report" } };
    Note that you can use the same technique with polymorphic *lists*, in which case the serializer will expect sequences of elements with the specified names:
        [XmlRoot("RootXml", Namespace = "")]
        public class RootXml
        {
            public RootXml() { }
            List<object> _test;
            [XmlElement("Report", Type=typeof(Report))]
            [XmlElement("DifferentReport", Type = typeof(DifferentReport))]
            public List<object> Data
            {
                get { return _test; }
                set { _test = value; }
            }
        }
