    public static DataTable ToDataTable<T>(this T Item) where T: class
            {
                DataTable dataTable = new DataTable();
                PropertyDescriptorCollection propertyDescriptorCollection =
                    TypeDescriptor.GetProperties(typeof(T));
                for (int i = 0; i < propertyDescriptorCollection.Count; i++)
                {
                    PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                    Type type = propertyDescriptor.PropertyType;
    
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        type = Nullable.GetUnderlyingType(type);
    
    
                    dataTable.Columns.Add(propertyDescriptor.Name, type);
                }
                object[] values = new object[propertyDescriptorCollection.Count];
                
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = propertyDescriptorCollection[i].GetValue(Item);
                    }
    
                    dataTable.Rows.Add(values);
                
                return dataTable;
            }
