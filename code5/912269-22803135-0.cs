    private string SomeString = null;
    
    ...
    table.Rows.Add(2, ReturnNullValue(SomeString, "---"));
    private string ReturnNullValue(string Value, string NullValue) 
    {
        if (String.IsNullOrEmpty(Value) == true)
        {
            return NullValue;
        }
        return Value;
    }
