    if (obj["IPAddress"] != null) // IPAddress is of type System.String[]
         {
            string[] newStringArray = obj["IPAddress"].ToArray();
             foreach (string s in newStringArray )
             { 
                 Console.WriteLine(s);         
             }
         }
