    public sealed class ModelMetaTypeAttribute : Attribute
    {
        public ModelMetaTypeAttribute(Type modelType)
        {
            ModelType = modelType;
        }
        public Type ModelType { get; private set; }
    }
    public static class ModelMetaTypeUtilities
    {
        private static readonly Dictionary<PropertyInfo, ICollection<Attribute>> MetaAttributesCache = new Dictionary<PropertyInfo, ICollection<Attribute>>();
        public static ICollection<Attribute> GetMetaAttributes(this PropertyInfo propertyInfo)
        {
            // Lookup from cache if possible
            var key = propertyInfo;
            if (MetaAttributesCache.ContainsKey(key)) return MetaAttributesCache[key];
            //Try the metadataType instead as well
            ICollection<Attribute> attributes = new List<Attribute>();
            var classType = propertyInfo.DeclaringType ?? propertyInfo.ReflectedType;
            var metadataTypeAttribute = classType.GetCustomAttribute<ModelMetaTypeAttribute>();
            if (metadataTypeAttribute != null)
            {
                var metadataType = metadataTypeAttribute.ModelType;
                var metadataPropertyInfo = metadataType.GetProperty(propertyInfo.Name);
                if (metadataPropertyInfo != null)
                {
                    attributes = metadataPropertyInfo.GetCustomAttributes().ToList();
                }
            }
            MetaAttributesCache.Add(key, attributes);
            return attributes;
        }
    }
    // For more info see: http://geekswithblogs.net/brians/archive/2010/06/14/asp.net-mvc-localization-displaynameattribute-alternatives-a-better-way.aspx
    public class CustomDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var allAttributes = IncludeMetaAttributes(containerType, propertyName, attributes);
            var meta = base.CreateMetadata(allAttributes, containerType, modelAccessor, modelType, propertyName);
            return meta;
        }
        private static IEnumerable<Attribute> IncludeMetaAttributes(Type containerType, string propertyName, IEnumerable<Attribute> attributes)
        {
            var propertyInfo = !propertyName.IsNullOrEmpty() ? containerType.GetProperty(propertyName) : null;
            if (propertyInfo == null) return attributes;
            var metaAttributes = propertyInfo.GetMetaAttributes();
            return attributes.Concat(metaAttributes);
        }
    }
