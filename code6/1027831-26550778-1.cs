     public static class DalExtensions {
        // DbSet Names is the plural property name in the context
        public static List<string> GetModelNames(this DbContext context) {
            var propList = context.GetType().GetProperties();
            return GetDbSetNames(propList);
        }
        // DbSet Names is the plural property name in the context
        public static List<string> GetDbSetTypeNames<T>() where T : DbContext {
            var propList = typeof (T).GetProperties();
            return GetDbSetNames(propList);
        }
        // DBSet Types is the Generic Types POCO name  used for a DBSet
        public static List<string> GetModelTypes(this DbContext context) {
            var propList = context.GetType().GetProperties();
            return GetDbSetTypes(propList);
        }
        // DBSet Types POCO types as IEnumerable List
        public static IEnumerable<Type> GetDbSetPropertyList<T>() where T : DbContext {
            return typeof (T).GetProperties().Where(p => p.PropertyType.GetTypeInfo()
                                                          .Name.StartsWith("DbSet"))
                             .Select(propertyInfo => propertyInfo.PropertyType.GetGenericArguments()[0]).ToList();
        }
        // DBSet Types is the Generic Types POCO name  used for a DBSet
        public static List<string> GetDbSetTypes<T>() where T : DbContext {
            var propList = typeof (T).GetProperties();
            return GetDbSetTypes(propList);
        }
        private static List<string> GetDbSetTypes(IEnumerable<PropertyInfo> propList) {
            var modelTypeNames = propList.Where(p => p.PropertyType.GetTypeInfo().Name.StartsWith("DbSet"))
                                         .Select(p => p.PropertyType.GenericTypeArguments[0].Name)
                                         .ToList();
            return modelTypeNames;
        }
        private static List<string> GetDbSetNames(IEnumerable<PropertyInfo> propList) {
            var modelNames = propList.Where(p => p.PropertyType.GetTypeInfo().Name.StartsWith("DbSet"))
                                     .Select(p => p.Name)
                                     .ToList();
            return modelNames;
        }
    }
}
