               DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
               DataTable userTables = null;
               using (DbConnection connection = factory.CreateConnection())
               {
                   
                   connection.ConnectionString = "Provider=Microsoft.Ace.OLEDB.12.0;Data  
                   Source=C:\test\testfile.accdb;Jet OLEDB:Database Password=yourrPassword;";
                    string[] restrictions = new string[4];
                    restrictions[3] = "Table";
                    connection.Open();
                    // Get list of user tables
                    userTables = connection.GetSchema("Tables", restrictions);
                    
                }
