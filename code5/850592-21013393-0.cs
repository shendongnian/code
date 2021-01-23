    LuaTable tb = lua.GetTable("config");
    
    Dictionary<object, object> dict = lua.GetTableDict(tb);
    foreach (KeyValuePair<object, object> de in dict)
    {
        Console.WriteLine("{0} {1}", de.Key.ToString(), de.Value.ToString());
    }
