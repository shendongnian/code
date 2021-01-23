    public class HREntities : DbContext {
        public HREntities(string connectionString)
            : base(connectionString) {
        }
        public HREntities(string connectionString, Type entityType)
            : base(connectionString, GenerateDbCompiledModel(connectionString, entityType)) {
        }
        private static DbCompiledModel GenerateDbCompiledModel(string connectionString, Type entityType) {
            string tableName;
            if (typeof(DynamicEntity).IsAssignableFrom(entityType)) {
                tableName = entityType.Name.Substring((DynamicEntity.DynamicTypePrefix + "tbl").Length);
            }
            else {
                tableName = entityType.Name.Substring("tbl".Length);
            }
            DbModelBuilder dbModelBuilder = new DbModelBuilder(DbModelBuilderVersion.Latest);
            var entityMethod = dbModelBuilder.GetType().GetMethod("Entity").MakeGenericMethod(entityType);
            var entityTypeConfiguration = entityMethod.Invoke(dbModelBuilder, new object[0]);
            entityTypeConfiguration.GetType().GetMethod("ToTable", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string) }, null).Invoke(entityTypeConfiguration, new object[] { tableName });
            return dbModelBuilder.Build(new SqlConnection(connectionString)).Compile();
        }
    }
