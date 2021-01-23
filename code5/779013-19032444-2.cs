        public class ModelSummary
        {
            public Dictionary<string, System.Data.Metadata.Edm.EntityType> Entities { get; private set; }
            public static ModelSummary Load(DbContext context)
            {
                  var adapter = (IObjectContextAdapter)context;
                  var objectContext = adapter.ObjectContext;
                    
                    var summary = new ModelSummary();
                  var items = objectContext.MetadataWorkspace.GetItems(DataSpace.SSpace);
                  summary.Entities =
                    objectContext.MetadataWorkspace.GetItems(DataSpace.SSpace)
                    .OfType<EntityType>()
                    .ToDictionary(et => et.Name);
                return summary;
           
            }
            
            public bool EntityExists(string entityName)
            {
                return this.Entities.ContainsKey(entityName);
            }
            public bool EntityHasProperty(string entityName, string propertyName)
            {
                if (!EntityExists(entityName))
                {
                    return false;
                }
                var entity = this.Entities[entityName];
                return entity.Properties.Contains(propertyName);
            }
        }
