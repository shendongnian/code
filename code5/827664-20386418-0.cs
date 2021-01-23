        Private void SetProperty(Object ctrl, string propertyName, string value)
        {
            string name = propertyName.Split('.').First();
            PropertyInfo property = ctrl.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (name != propertyName)
            {
                ctrl = property.GetValue(ctrl, null);
                SetProperty(ctrl, propertyName.Replace(string.Concat(name, "."), string.Empty), value);
                return;
            }
            TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
            if (converter != null && converter.CanConvertFrom(typeof(String)))
                    property.SetValue(ctrl, converter.ConvertFrom(value), null);
        }
