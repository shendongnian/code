    string connectionString = Dts.Connections[connMgrName].ConnectionString;    //  ConnectionString will contain unsupported keywords like 'provider'
    connectionString = connectionString.Trim(';'); //  Remove the trailing semicolon so that when we perform the split in the following line, there are no index errors.
    var connStrDictionary = connectionString.Split(';').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);     //   Here we get each value-pair from connection string by splitting by ';', then splitting each element by '=' and adding the pair to a Dictionary.
    try
    {
    	connectionString = "Data Source=" + connStrDictionary["Data Source"] + ";Initial Catalog=" + connStrDictionary["Initial Catalog"] + ";Integrated Security=" + connStrDictionary["Integrated Security"];	//	Build the actual connection string to be used.
    }
    catch(KeyNotFoundException)
    {
    	Console.WriteLine("\t\tNot able to build the connection string due to invalid keyword used. Existing keywords and their values:");
    	foreach( KeyValuePair<string, string> kvp in connStrDictionary)
    	{
    		Console.WriteLine("\t\t\tKey = '{0}', Value = '{1}'", kvp.Key, kvp.Value);
    	}
    }
