cs
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
// ...
using ( var db = new YourContext() )
{
  var metadataWorkspace = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db)
  .ObjectContext.MetadataWorkspace;
  var itemCollection = ((StorageMappingItemCollection)metadataWorkspace
  .GetItemCollection(DataSpace.CSSpace));
  var entityMappings = itemCollection.OfType<EntityContainerMapping>().Single()
  .EntitySetMappings.ToList();
  var entityMapping = (EntityTypeMapping)entityMappings
    .Where(e => e.EntitySet.ElementType.FullName == typeof(TEntity).FullName)
    //or .Where(e => e.EntitySet.ElementType.Name == "YourEntityName")
    .Single().EntityTypeMappings.Single();
  var fragment = entityMapping.Fragments.Single();
  var dbTable = fragment.StoreEntitySet;
  Console.WriteLine($"Entity {entityMapping.EntityType.FullName} is mapped to table [{dbTable.Schema}].[{dbTable.Name}]");
  var scalarPropsMap = entityMapping.Fragments.Single()
  .PropertyMappings.OfType<ScalarPropertyMapping>();
  foreach(var prop in scalarPropsMap)
    Console.WriteLine($"Property {prop.Property.Name} maps to Column {prop.Column.Name}");
}
Out of curiosity I use the code above because `System.Data.SqlClient.SqlBulkCopy` requires mapping between entity properties and table columns.
