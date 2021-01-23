    using ( var context = new YourEntities() )
    {
      var objectContext = ( ( IObjectContextAdapter )context ).ObjectContext;
      var storageMetadata = ( (EntityConnection)objectContext.Connection ).GetMetadataWorkspace().GetItems( DataSpace.SSpace );
      var entityProps = ( from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType );
      var personRightStorageMetadata = ( from m in entityProps where m.Name == "PersonRight" select m ).Single();
      foreach ( var item in personRightStorageMetadata.Properties )
      {
          Console.WriteLine( item.Name );
      }
    }
