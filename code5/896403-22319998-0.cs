       XDocument doc = XDocument.Load(Your XML);
        var elements = doc.Descendants( "names" );
        Dictionary<string, string> keyValues = new Dictionary<string, string>();
        for (int i = 0; i < elements.Count; i++)
        {
           string key = elements[i].Attributes["key"].Value.ToString();
           string value = elements[i].Attributes["value"].Value.ToString();
           keyValues.Add(key,value);
        }  
