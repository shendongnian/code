    private IEnumerable<PropertyInfo> GetUpdateableProperties<T>(T entity) where T : IEntity
        {
            return entity.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .Where(property =>
                    property.CanWrite &&
                    !property.PropertyType.GetInterfaces().Contains(typeof(IEntity)) &&
                    !(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                    );
        }
