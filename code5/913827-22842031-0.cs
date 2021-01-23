    public string GetPropertyByName(SectionsEnum s)
    {
        var property = typeof(Person).GetProperty(s.ToString());
        return (string)property.GetValue(this);
    }
