     using (XmlReader reader = XmlReader.Create(@"C:\Users\Kavindu\Desktop\forecast.xml"))
      {
          // Walk through all 
          while (reader.Read())
          {
             // If we meet time element ; go inside and walk 
             if (reader.Name == "time")
             {
                   // Extract 'from' attribute 
                   String from = reader["from"];
                   if (from != null)
                   {
                            Console.WriteLine("From : "+from);
                   }
                   // Now walk through all elements inside same Time element
                   // Here I use do-while ; what we check is End element of time : </time> .. when we walk till we meet </time> we are inside children of same Time
                   // That mean we start from <time> and walk till we meet </time>
                   do
                   {
                        reader.Read();
                        if (reader.Name == "symbol")
                        {
                             String name = reader["name"];
                             if (name != null)
                             {
                                  Console.WriteLine("\t Symbol name :" + name);
                             }
                        }
                  } while (reader.NodeType != XmlNodeType.EndElement && reader.Name != "time");
              }
        }
    }
  
