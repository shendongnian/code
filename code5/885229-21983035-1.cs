    namespace MyApp
    {
        class DatabaseInterface
        {
            public static string getConnectionString()
            {
                return myFlag ? "Data Source=server;Initial Catalog=db" : "AnotherString";
            }
        }  
     }
