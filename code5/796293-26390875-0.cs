    public class DeltaContractResolver : CamelCasePropertyNamesContractResolver
    {
            protected override JsonContract CreateContract(Type objectType)
            {
                // This class special cases the JsonContract for just the Delta<T> class. All other types should function
                // as usual.
                if (objectType.IsGenericType &&
                    objectType.GetGenericTypeDefinition() == typeof(Delta<>) &&
                    objectType.GetGenericArguments().Length == 1)
                {
                    var contract = CreateDynamicContract(objectType);
                    contract.Properties.Clear();
    
                    var underlyingContract = CreateObjectContract(objectType.GetGenericArguments()[0]);
                    var underlyingProperties =
                        underlyingContract.CreatedType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in underlyingContract.Properties)
                    {
                        property.DeclaringType = objectType;
                        property.ValueProvider = new DynamicObjectValueProvider()
                        {
                            PropertyName = this.ResolveName(underlyingProperties, property.PropertyName),
                        };
    
                        contract.Properties.Add(property);
                    }
    
                    return contract;
                }
    
                return base.CreateContract(objectType);
            }
    
            private string ResolveName(PropertyInfo[] properties, string propertyName)
            {
                
                var prop = properties.SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
    
                if (prop != null)
                {
                    return prop.Name;
                }
    
                return propertyName;
            }
    }
