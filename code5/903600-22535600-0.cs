        var xmlSer = new XmlSerializer(typeof (Code));
        var code = new Code {Value = "xx"};
        var sb = new StringBuilder();
        var wri = new StringWriter(sb);
        xmlSer.Serialize(wri, code);
        Console.WriteLine(sb.ToString());
        [XmlRoot(ElementName = "Code")]
        public class Code
        {
            [XmlText]
            public string Value { get; set; }
        }
