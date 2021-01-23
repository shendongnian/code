    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Core.Objects;
    using System.Data.SqlClient;
    
    namespace Northwind.Model {
        public partial class NorthwindEntities {
            public NorthwindEntities(string connectionString)
                : base(GetObjectContext(connectionString), true) {
            }
    
            private static ObjectContext GetObjectContext(string connectionString) {
                // You can use the metadata portion of the connection string the the designer added to your config for the paths
                var paths = new[] { 
                    "res://*/Northwind.csdl", 
                    "res://*/Northwind.ssdl", 
                    "res://*/Northwind.msl"
                };
    
                var workspace = new MetadataWorkspace(paths, new[] { typeof(NorthwindEntities).Assembly });
                var connection = new EntityConnection(workspace, new SqlConnection(connectionString));
    
                return new ObjectContext(connection);
            }
        }
    }
