    protected IEnumerable<Request> ProcessResults(byte[] result) {
        var serializer = new XmlSerializer(typeof(Request[]), new XmlRootAttribute("DataService") {Namespace = ""});
        var isoEncoder = Encoding.GetEncoding("ISO-8859-1");
        var resultString = isoEncoder.GetString(result);
        using (var xmlReader = new XmlTextReader(new StringReader(resultString))) {
            var requests = (Request[])serializer.Deserialize(xmlReader);
            return requests;
        }
    }
