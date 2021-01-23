      using (XmlReader reader = XmlReader.Create(@"C:\Users\Kavindu\Desktop\forecast.xml"))
       {
          // Walk through all 
          while (reader.Read())
          {
             // If we meet time element ; go inside
             if (reader.Name == "time")
             {
                   // Extract from property
                   String from = reader["from"];
                   if (from != null)
                   {
                            Console.WriteLine("From : "+from);
                   }
                   // Now walk through all elements inside same Time element
                   while (reader.NodeType != XmlNodeType.EndElement)
                   {
                      reader.Read();
                      // Reach the symbol element and read attributes
                      if (reader.Name == "symbol")
                      {
                           String name = reader["name"];
                           if (name != null)
                           {
                             Console.WriteLine("\t Symbol name :"+name);
                           }
                       }
                   }
           }
        }
    }
  
