     using (XmlReader reader = XmlReader.Create(@"http://api.openweathermap.org/data/2.5/forecast?q=lahti,fin&mode=xml"))
     {
          // Walk through all Elements 
          while (reader.Read())
          {
             // If we meet time element ; go inside and walk 
             if (reader.Name == "time")
             {
                   Console.WriteLine("A new TIME ");
                   // Extract from attribute
                   String from = reader["from"];
                   if (from != null)
                   {
                        Console.WriteLine("\t From : " + from);
                   }
                   // Now walk through all elements inside same Time element
                   // Here I use do-while ; what we check is End element of time : </time> .. when we walk till we meet </time> we are inside children of same Time
                   // That mean we start from <time> and walk till we meet </time>
                   do
                   {
                        reader.Read();
                        if (reader.Name == "symbol")
                        {
                             // You can use this approach for any Attribute in symbol Element
                             String name = reader["name"];
                             if (name != null)
                             {
                                  Console.WriteLine("\t Symbol name :" + name);
                             }
                        }
                        
                        if (reader.Name == "clouds")
                        {
                             String clouds = reader["value"];
                             if (clouds != null)
                             {
                               Console.WriteLine("\t\t Clouds value : " + clouds);
                             }
                         }
                  } while (reader.NodeType != XmlNodeType.EndElement && reader.Name != "time");
              }
          }
    }
  
