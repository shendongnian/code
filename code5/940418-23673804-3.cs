    foreach (PropertyInfo prop in result.GetType().GetProperties())
    { 
        var propValue = prop.GetValue(result,null);
        if(propValue is string)
        {
            // do something with string
            continue; // to skip checking for other types
        }
        if(propValue is bool)
        {
            // do something with bool
            continue;
        }
        // do something with object
    }
