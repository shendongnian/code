    try
    {
        var myValue = Registry.GetValue( ... );  // throws exception on invalid keyName
        if (myValue != null)
            Registry.SetValue( ... );
    }
    catch (ArgumentException ex)
    {
        // do something like tell user that path is invalid
    }
