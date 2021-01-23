    string xml = @"
    <a>
        <b>
            <b c=""1"" ></b>
            <b c=""2"" ></b>
            <b c=""3"" ></b>
            <b c=""4"" ></b>
        </b>
    </a>";
    var bs = XDocument.Parse(xml)
                        .Root
                        .Element("b")
                        .Elements("b")
                        .Select(b => new B { c = b.Attribute("c").Value })
                        .ToList();
.
    public class B
    {
        public string c = "foo";
    }
