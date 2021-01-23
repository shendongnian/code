    public Dictionary<string, string> GetInputMessage(Table table)
    {
        var elements = new Dictionary<string, string>();
        foreach(var item in table.CreateSet<SpecFlowData>())
        {
           elements.Add(item.Field, item.Value);
        }
        return elements;
    }
