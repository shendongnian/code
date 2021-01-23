    // Use `XmlReader`
    using (XmlReader reader = XmlReader.Create(@"PATH"))
    {
         // we walk through full document
         while (reader.Read())
         {
             // Only read start elements : <ELEMENT> 
             if (reader.IsStartElement())
             {
                   // If name is time.. we try to extract from parameter
                   if (reader.Name == "time")
                   {
                      String from=reader["from"];
                      if (from!=null)
                      {
                          Console.WriteLine(from);
                      }
               }
               
               // If name is precipitation.. we try to extract value parameter
               if (reader.Name == "precipitation")
               {
                    String percep = reader["value"];
                    if (percep != null)
                    {
                         Console.WriteLine(percep);
                     }
                 }
           }                  
      }
   
