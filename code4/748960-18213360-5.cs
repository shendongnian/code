    {
        // You are using a namespace! 
        XNamespace ns = "http://www.w3schools.com/xml/";
        var xml2 = XDocument.Parse(xml);
        // Compress
        {
            // Will compress all the XElement that are called Claim
            // You should probably select the XElement in a better way
            var nodes = from p in xml2.Descendants(ns + "Claim") select p;
            foreach (XElement el in nodes)
            {
                CompressElementContent(el);
            }
        }
        // Decompress
        {
            // Will decompress all the XElement that are called Claim
            // You should probably select the XElement in a better way
            var nodes = from p in xml2.Descendants(ns + "Claim") select p;
            foreach (XElement el in nodes)
            {
                DecompressElementContent(el);
            }
        }
    }
    public static void CompressElementContent(XElement el)
    {
        string content;
        using (var reader = el.CreateReader())
        {
            reader.MoveToContent();
            content = reader.ReadInnerXml();
        }
        using (var ms = new MemoryStream())
        {
            using (DeflateStream defl = new DeflateStream(ms, CompressionMode.Compress))
            {
                // So that the BOM isn't written we use build manually the encoder.
                // See for example http://stackoverflow.com/a/2437780/613130
                // But note that false is implicit in the parameterless constructor
                using (StreamWriter sw = new StreamWriter(defl, new UTF8Encoding()))
                {
                    sw.Write(content);
                }
            }
            string base64 = Convert.ToBase64String(ms.ToArray());
            el.ReplaceAll(new XText(base64));
        }
    }
    public static void DecompressElementContent(XElement el)
    {
        var reader = el.CreateReader();
        reader.MoveToContent();
        var content = reader.ReadInnerXml();
        var bytes = Convert.FromBase64String(content);
            
        using (var ms = new MemoryStream(bytes))
        {
            using (DeflateStream defl = new DeflateStream(ms, CompressionMode.Decompress))
            {
                using (StreamReader sr = new StreamReader(defl, Encoding.UTF8))
                {
                    el.ReplaceAll(ParseXmlFragment(sr));
                }
            }
        }
    }
    public static IEnumerable<XNode> ParseXmlFragment(StreamReader sr)
    {
        var settings = new XmlReaderSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment
        };
        using (var xmlReader = XmlReader.Create(sr, settings))
        {
            xmlReader.MoveToContent();
            while (xmlReader.ReadState != ReadState.EndOfFile)
            {
                yield return XNode.ReadFrom(xmlReader);
            }
        }
    }
