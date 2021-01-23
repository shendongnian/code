    while (reader.Read())
    {
    Console.WriteLine(reader.GetInt32(0));  // for Int
    //OR
    Console.WriteLine(reader.GetString(0));  // for strings
     
    }
 
