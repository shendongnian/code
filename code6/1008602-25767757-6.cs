    private void DeserializeProperty(object value, 
                                     PropertyInfo property, Format format) {
        if (value == DBNull.Value || value == null) {
             property.SetValue(this, null);
        }
        else if (property.PropertyType == typeof(Id)) {
             SetIdProperty(value, property);
        }
        else if (property.PropertyType.BaseType == typeof(BaseProperty)) {
             SetBaseProperty(value, property);
        }
        else if (property.PropertyType == typeof(Data)) {
             DeserializeData(value, property, format);
        }
        else {
             DeserializeNormalProperty(property, value);
        }
     }
