    static MyObject ParseMyObject(XElement dict)
    {
        var values = dict.Elements("key")
                         .ToDictionary(k => (string)k, k => (XElement)k.NextNode);
        return new MyObject {
            MainTitle = (string)values["Title"],
            ListOfSubTitles = values["ID"].Elements().Select(s => (string)s).ToList()
        };
    }
