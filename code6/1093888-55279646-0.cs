    private static string DacPacFingerprint(string path)
    {
        using (var stream = File.OpenRead(path))
        using (var package = Package.Open(stream))
        {
            var extractors = new IDacPacDataExtractor [] {new ModelExtractor(), new PostScriptExtractor()};
            string content = string.Join("_", extractors.Select(e =>
            {
                var modelFile = package.GetPart(new Uri($"/{e.Filename}", UriKind.Relative));
                using (var streamReader = new StreamReader(modelFile.GetStream()))
                {
                    return e.ExtractData(streamReader);
                }
            }));
            using (var crypto = new MD5CryptoServiceProvider())
            {
                byte[] retVal = crypto.ComputeHash(Encoding.UTF8.GetBytes(content));
                return BitConverter.ToString(retVal).Replace("-", "");// hex string
            }
        }
    }
    private class ModelExtractor : IDacPacDataExtractor
    {
        public string Filename { get; } = "model.xml";
        public string ExtractData(StreamReader streamReader)
        {
            var xmlDoc = new XmlDocument() { InnerXml = streamReader.ReadToEnd() };
            foreach (XmlNode childNode in xmlDoc.DocumentElement.ChildNodes)
            {
                if (childNode.Name == "Header")
                {
                    // skip the Header node as described
                    xmlDoc.DocumentElement.RemoveChild(childNode);
                    break;
                }
            }
    
            return xmlDoc.InnerXml;
        }
    }
    
    private class PostScriptExtractor : IDacPacDataExtractor
    {
        public string Filename { get; } = "postdeploy.sql";
        public string ExtractData(StreamReader stream)
        {
            return stream.ReadToEnd();
        }
    }
    
    private interface IDacPacDataExtractor
    {
        string Filename { get; }
        string ExtractData(StreamReader stream);
    }
