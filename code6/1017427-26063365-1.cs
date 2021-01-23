    private IList GetPropertiesList(PropertyDescriptorCollection collection, string parent)
            {
                ArrayList result = new ArrayList();
                ArrayList innerProperties = new ArrayList();
                if (parent != string.Empty)
                    parent += '.';
                foreach (PropertyDescriptor property in collection)
                {
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(DateTime) || property.PropertyType.IsPrimitive)
                        result.Add(parent + property.Name);
                    else
                    {
                        parent += property.Name;
                        innerProperties = (ArrayList)GetPropertiesList(property.GetChildProperties(), parent);
                    }
                }
                if (innerProperties.Count > 0)
                    result.AddRange(innerProperties);
                return result;
            }
