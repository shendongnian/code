    XDocument xdoc = XDocument.Load(path);    
    var apiMap = xdoc.Root.Elements()
                     .Select(a => new
                         {
                             ApiName = (string)a.Attribute("apiName"),
                             ApiMessage = (string)a.Attribute("apiMessage")
                         });
    var duplicateKeys = (from x in apiMap
                         group x by x.ApiName into g
                         select new { ApiName = g.Key, Cnt = g.Count() })
                         .Where(x => x.Cnt > 1)
                         .Select(x => x.ApiName);
    if (duplicateKeys.Count() > 0)
        throw new InvalidOperationException("The following keys are present more than once: " 
                + string.Join(", ", duplicateKeys));
    Dictionary<string, string> apiMapDict = 
        apiMap.ToDictionary(a => a.ApiName, a => a.ApiMessage);
