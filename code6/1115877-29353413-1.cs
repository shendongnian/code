    try
    {
    cmd = command.SetupCommand(cnn, info.ParamReader);
    if (wasClosed) cnn.Open();
                
    // We can't use SequentialAccess any more - this will have a performance hit.
    reader = cmd.ExecuteReader(wasClosed ? CommandBehavior.CloseConnection : CommandBehavior.Default);
    wasClosed = false; 
    // You'll need to make sure your typePrefix is correct to your type's namespace
    var assembly = Assembly.GetExecutingAssembly();
    var typePrefix = assembly.GetName().Name + ".";
    while (reader.Read())
    {
        // This has been moved from outside the while
        int hash = GetColumnHash(reader);
                    
        if (reader.FieldCount == 0) //https://code.google.com/p/dapper-dot-net/issues/detail?id=57
            yield break;
        // Now we're creating a new DeserializerState for every row we read 
        // This can be made more efficient by caching and re-using for matching types
        var discriminator = reader["discriminator"].ToString();
        var convertToType = assembly.GetType(typePrefix + discriminator);
        var tuple = info.Deserializer = new DeserializerState(hash, GetDeserializer(convertToType, reader, 0, -1, false));
        if (command.AddToCache) SetQueryCache(identity, info);
                    
        // The rest is the same as before except using our type in ChangeType
        var func = tuple.Func;
                    
        object val = func(reader);
        if (val == null || val is T)
        {
            yield return (T)val;
        }
        else
        {
            yield return (T)Convert.ChangeType(val, convertToType, CultureInfo.InvariantCulture);
        }
    }
    // The rest of this method is the same
