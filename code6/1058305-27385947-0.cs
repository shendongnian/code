    public static MyContext CreateContext(string location)
        {
            MyContext result = null;
            string databaseName = string.Empty;
            switch(location)
            {
               case "NY":
                  databaseName = "NyDb";
                  break;
              case "LA":
                  databaseName = "LaDb";
                  break;
            }
            
            
            var connectionName = "Name=" + databaseName;
            result = new MyContext(connectionName);
            return result;
        }
