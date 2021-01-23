    public class DbEntityPropertyValues<EntityType> where EntityType : MyEntity {
        private readonly Dictionary<string, object> entityKeyValuePairs = new Dictionary<string, object>();
        public DbEntityPropertyValues (DbPropertyValues dbPropertyValues) {
            IEnumerable<string> dbPropertyNames = dbPropertyValues.PropertyNames;
            foreach(var prop in dbPropertyNames) {
                entityKeyValuePairs.Add(prop, dbPropertyValues.GetValue<Object>(prop));
            }
        }
        //Intended only for testing.
        //A detached entity gets passed in instead of DbPropertyValues which can't be mocked.
        public DbEntityPropertyValues (CompanyEntity entity) {
            IEnumerable<PropertyInfo> entityProperties = typeof(EntityType).GetProperties().AsEnumerable();
            foreach (var prop in entityProperties) {
                entityKeyValuePairs.Add(prop.Name, entity.GetType().GetProperty(prop.Name).GetValue(entity, null));
            }
        }
        public T GetValue<T> (string propertyName) {
            if (!typeof(T).Equals(typeof(EntityType).GetProperty(propertyName).PropertyType)) {
                throw new ArgumentException(String.Format("{0} of type {1} does not exist on entity {2}", propertyName, typeof(T), typeof(EntityType)));
            }
            return (T)entityKeyValuePairs[propertyName];
        }
    }
