    foreach(var general in generals)  // probably only 1
    {
       foreach (var server in general.Elements("server"))
       {
           string serverName = server.Attribute("name").value;
    
           foreach(var service  in server.Elements("service"))
           {
               // etc
           }
       }
    }
