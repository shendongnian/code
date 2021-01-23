    private IList GetPropertiesList(PropertyDescriptorCollection collection, string parent)
            {
                ArrayList result = new ArrayList();
                if (parent != string.Empty)
                    parent += '.';
                foreach (PropertyDescriptor property in collection)
                {
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(DateTime) || property.PropertyType.IsPrimitive)
                        result.Add(parent + property.Name);
                    else
                    {
                        result.AddRange((ArrayList)GetPropertiesList(property.GetChildProperties(), parent+ property.Name));
                    }
                }
                return result;
            }
