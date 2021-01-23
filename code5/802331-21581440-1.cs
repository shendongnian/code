    public bool CompareJson(string expected, string actual)
    {
        var expectedDoc = JsonConvert.DeserializeXmlNode(expected, "root");
        var actualDoc = JsonConvert.DeserializeXmlNode(actual, "root");
        var diff = new XmlDiff(XmlDiffOptions.IgnoreWhitespace |
                               XmlDiffOptions.IgnoreChildOrder);
        using (var ms = new MemoryStream())
        {
            var writer = new XmlTextWriter(ms, Encoding.UTF8);
            var result = diff.Compare(expectedDoc, actualDoc, writer);
            if (!result)
            {
                ms.Seek(0, SeekOrigin.Begin);
                Console.WriteLine(new StreamReader(ms).ReadToEnd());
            }
            return result;
        }
    }
