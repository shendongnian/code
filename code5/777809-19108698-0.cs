    static public string ToJSON(this object item)
    {
      var myval = JsonSerializer.SerializeToString(item);
      return myval;
    }
    static public T FromJSON<T>(string code)
    {
       var item = JsonSerializer.DeserializeFromString<T>(code);
       return item;
    }
