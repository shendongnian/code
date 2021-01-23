        public class CustomAttributeContractResolver : DefaultContractResolver
        {	
            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                JsonObjectContract contract =
                    base.CreateObjectContract(objectType);
                
                IEnumerable<JsonProperty> withoutConverter =
                    contract.Properties.Where(
                        pr => pr.MemberConverter == null && 
                        pr.Converter == null);
                
                // Go over the results of calling the default implementation.
                // check properties without converters for your custom attribute
                // and pull the custom converter out of that attribute.
                foreach (JsonProperty property in withoutConverter)
                {
                    PropertyInfo info = 
                        objectType.GetProperty(property.UnderlyingName);
                        
                    var converterAttribute =
                        info.GetCustomAttribute<ConverterAttribute>();
                    
                    if (converterAttribute != null)
                    {
                        property.Converter = converterAttribute.Converter;
                        property.MemberConverter = converterAttribute.Converter;
                    }
                }
                
                return contract;
            }
        }
