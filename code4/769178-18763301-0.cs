    void SetLongName(Shape shape, string uniqueId, string longName)
    {
        shape.Name = uniqueId;
        Variables vars = Doc.Variables;
        var = vars.Add(uniqueId, longName);
    }
    string GetLongNameOfShape(Shape shape)
    {
        return GetLongNameById(shape.Name);
    }
    string GetLongNameById(string uniqueId)
    {
        Variables vars = Doc.Variables;
        return vars.get_Item(uniqueId).Value;
    }
