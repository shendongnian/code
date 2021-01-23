    MetadataWorkspace workspace = new MetadataWorkspace(
      new string[] { "res://*/" }, 
      new Assembly[] { Assembly.GetExecutingAssembly() });
    
    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    using (EntityConnection entityConnection = new EntityConnection(workspace, sqlConnection))
    using (NorthwindEntities context = new NorthwindEntities(entityConnection))
    {
      // do whatever on default database
      foreach (var product in context.Products)
      {
        Console.WriteLine(product.ProductName);
      }
    
      // switch database
      sqlConnection.ChangeDatabase("Northwind");
      Console.WriteLine("Database: {0}", connection.Database);
    }
