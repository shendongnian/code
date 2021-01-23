    public static SqlDataReader ExecuteReader(string CommandName, 
                                          SqlConnection Connection,
                                          params[] KeyValuePair<string, object> parameters)
    //...
    foreach (var p in parameters)
       cmd.Parameters.Add(p.Key, p.Value)
    //...
