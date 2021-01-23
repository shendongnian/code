     using (var db=new YourContext())
     {
       var workspace = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
       var itemCollection = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));
       var entityType = itemCollection.OfType<EntityType>().Single(e => itemCollection.GetClrType(e) == typeof(YourEntity));
       foreach (var navigationProperty in entityType.NavigationProperties)
       {
          Console.WriteLine(navigationProperty.Name);
       }
       foreach (var property in entityType.Properties)
       {
          Console.WriteLine(property.Name);
       }
    }
