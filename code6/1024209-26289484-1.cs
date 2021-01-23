       var collection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings ?? System.Configuration.ConfigurationManager.ConnectionStrings;
            
            if (collection[1].Name == null)
                throw new Exception("Unable to detect connection string in app.config or web.config! Default connection string name is \'DbConnection.\'");
            db = new Database(collection[1].Name);
