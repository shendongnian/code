    public string Bar(string constName)
    {
        Type t = typeof(Foo);
        return t.GetField(constName).GetValue(null));
    }
    
