    public static class EntityMapper
    {
        public static void Map(object from, object to)
        {
            var properties = to.GetType().GetProperties().Where(prop => !Attribute.IsDefined(prop, typeof(NotMappedAttribute)));
            foreach (var propertyToMap in properties)
            {
                var value = propertyToMap.GetValue(from);
                propertyToMap.SetValue(to, value);
            }
        }
    }
