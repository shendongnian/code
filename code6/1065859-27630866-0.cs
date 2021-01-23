    DateTime dateTime1;
    if (DateTime.TryParse((string)Registry.GetValue(keyName, valueT1, DateTime.MinValue),
        out dateTime1))
    {
         ........      
    }
