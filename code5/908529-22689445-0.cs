            Type resourceType = _Resource.GetType();
            IList<PropertyInfo> props = resourceType.GetProperties();
            if (_MappingMod == MappingMod.AllPropertiesAndNotEnumerableProperties || _MappingMod == MappingMod.NotNullPropertiesAndNotEnumerableProperties)
            {
                props = props.Where(m => m.GetGetMethod().IsVirtual != true).ToList();
            }
            Type destinationType = _Destination.GetType();
            foreach (PropertyInfo prop in props)
            {
                PropertyInfo destinationProp = destinationType.GetProperty(prop.Name);
                if (destinationProp != null)
                {
                    if (AutoMappingController(_MappingMod, _Destination, _Resource, prop))
                    {
                        destinationProp.SetValue(_Destination, prop.GetValue(_Resource, null));
                    }
                }
            }
        }
    public enum MappingMod
{
    AllProperties,
    NotNullProperties,
    AllPropertiesAndNotEnumerableProperties,
    NotNullPropertiesAndNotEnumerableProperties
