    public void compressTheData(string xml)
    {
      XNamespace ns =  "http://www.w3schools.com/xml/";
      var xml2 = XDocument.Load(xml);   
   
      // Compress
      {
       var nodes = (from p in xml2.Descendants(ns + "Claim") select p).ToList();
        foreach (XElement el in nodes)
        {      
            CompressElementContent(el);           
        }
    }
    xml2.Save(xml);   
    }
    public static void CompressElementContent(XElement el)
    {
      string content = el.ToString();    
    
      using (var ms = new MemoryStream())
      {
        using (GZipStream defl = new GZipStream(ms, CompressionMode.Compress))
        {           
            using (StreamWriter sw = new StreamWriter(defl))
            {
                sw.Write(content); 
            }
        }
        string base64 = Convert.ToBase64String(ms.ToArray());  
        XElement newEl = new XElement("CompressedPart", new XText(base64));
        XAttribute attrib = new XAttribute("Type", "gzip");
        newEl.Add(attrib);
        el.ReplaceWith(newEl);
      }
     }
 
