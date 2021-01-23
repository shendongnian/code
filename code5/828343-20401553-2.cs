    class Program
    {
        static void Main(string[] args)
        {
            var capt = "OK:<IDP RESULT=\"0\" MESSAGE=\"some message\" ID=\"oaisjd98asdh339wnf\" MSGTYPE=\"Done\"/>";
            var stream = new MemoryStream(Encoding.Default.GetBytes(capt.Substring(capt.IndexOf("<"))));
            var kvpList = XDocument.Load(XmlReader.Create(stream))
                       .Elements().First()
                       .Attributes()
                       .Select(a => new
                       {
                           Attr = a.Name.LocalName,
                           Val = a.Value
                       });
        }
    }
