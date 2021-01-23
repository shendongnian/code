    public static class AttrHelper
    {
       public static T GetAttributeOfType<T>(this ViewDataDictionary viewData) where T : System.Attribute
        {
            var metadata = viewData.ModelMetadata;
            var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
            var attrs = prop.GetCustomAttributes(false);
            // Try and get the attribute directly from the property.
            T ret = attrs.OfType<T>().FirstOrDefault();
            // If there isn't one, look at inherited attribute info if there is any.
            if(ret == default(T))
            {
                AttributesFromAttribute inheritedAttributes = attrs.OfType<AttributesFromAttribute>().FirstOrDefault();
                if (inheritedAttributes != null)
                {
                    ret = inheritedAttributes.GetInheritedAttributeOfType<T>();
                }
            }
            // return what we've found.
            return ret;
        }
    }
