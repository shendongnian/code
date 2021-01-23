    string csvSeparator = ",";
    Func<string, string> escapeValue = val => val;
    
    string xml = "xml content";
    XDocument doc = XDocument.Parse(xml);
    
    var headers = doc.Root
                    .Elements()
                    .First()
                    .Elements()
                    .Select(el => el.Name.LocalName);
    
    var headerRow = string.Join(csvSeparator, headers);
    
    var rows = from el in doc.Root.Elements()
                let values = from prop in el.Elements()
                            select escapeValue(prop.Value)
                let row = string.Join(csvSeparator, values)
                select row;
    
    
    IEnumerable<string> csvLines = new[] { headerRow }.Concat(rows);
