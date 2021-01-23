    private readonly Dictionary<string, Action<string>> headerKeyCases;
    
    private A()
    {
        headerKeyCases = GetVariableGridParsersByName();
    }
    
    protected virtual void GetVariableGridParsersByName()
    {
        return new Dictionary<string, Action<string>>({
            { "a header", DoThis },
            { "another header", headerKey => DoThat(headerKey, "A") }
            // etc.
        });
    }
