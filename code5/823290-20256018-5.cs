    public static class ModelMetaDataExtensions
    {
        public static bool HasDisplayIfAttribute(this ModelMetadata data)
        {
            var containerType = data.ContainerType;
            var containerProperties = containerType.GetProperties();
            var thisProperty = containerProperties.SingleOrDefault(x => x.Name == data.PropertyName);
            var propertyAttributes = thisProperty.GetCustomAttributes(false);
            var displayIfAttribute = propertyAttributes.FirstOrDefault(x => x is DisplayIfAttribute);
            return displayIfAttribute != null;
        }
    }
