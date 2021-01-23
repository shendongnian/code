    {
        XNamespace ns = "http://www.w3schools.com/xml/";
        var xml2 = XDocument.Parse(xml);
        // Compress
        {
            // Here the ToList() is necessary, because we will replace the selected elements
            var nodes = (from p in xml2.Descendants(ns + "Claim") select p).ToList();
            foreach (XElement el in nodes)
            {
                CompressElementContent(el);
            }
        }
        // Decompress
        {
            // Here the ToList() is necessary, because we will replace the selected elements
            var nodes = (from p in xml2.Descendants("CompressedPart") select p).ToList();
            foreach (XElement el in nodes)
            {
                DecompressElementContent(el);
            }
        }
    }
    public static void CompressElementContent(XElement el)
    {
        string content = el.ToString();
        using (var ms = new MemoryStream())
        {
            using (DeflateStream defl = new DeflateStream(ms, CompressionMode.Compress))
            {
                // So that the BOM isn't written we use build manually the encoder.
                using (StreamWriter sw = new StreamWriter(defl, new UTF8Encoding()))
                {
                    sw.Write(content);
                }
            }
            string base64 = Convert.ToBase64String(ms.ToArray());
            var newEl = new XElement("CompressedPart", new XText(base64));
            el.ReplaceWith(newEl);
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
                    var newEl = XElement.Parse(sr.ReadToEnd());
                    el.ReplaceWith(newEl);
                }
            }
        }
    }
