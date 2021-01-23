    List<dynamic> dynamicSource = new List<dynamic>();
    foreach (var data in dataSource)
    {
        dynamic o = new ExpandoObject();
        // assigning properties we already know
        o.ID = data.ID;
        o.Name = data.Name;
        
        int idx = 0; // just a counter. you could also do this with a for-loop of course
        foreach (var item in data.List)
        {
            var dict = o as IDictionary<string, Object>; // cast expando object just to get the properties as key and value pairs in a dictionary
            dict.Add("ItemNr" + idx, item);
            idx++;
        }
        dynamicSource.Add(o);
    }
