    private string GetValueAsString(object obj)
    {
        if(obj == null) 
             return "(null)";
        if(obj is IEnumerable)
        {
             var values = ((IEnumerable)obj).Cast<object>();
             return "{" + string.Join(", ", values.Select(GetValueAsString)) + "}";
        }
        return obj.ToString();
    }
