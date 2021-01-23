        public static T ParseRecord<T>(this IDataRecord reader) where T : new()
        {
            var model = new T();
            var type = typeof(T);
            for (int i = 0; i < reader.FieldCount; i++) {
                var fieldType = reader.GetFieldType(i);
                var fieldName = reader.GetName(i);
                var val = reader.GetValue(i);
                var prop = type.GetProperty(fieldName);
                // handle or throw instead here if needed
                if (prop == null)
                    continue;
                var propType = prop.PropertyType;
                // HACK: remove this if you don't want to coerce to strings
                if (propType == typeof(string))
                    prop.SetValue(model, val.ToString());
                else if (fieldType != propType)
                    throw new Exception($"Type mismatch field {fieldType} != prop {propType}");
                else
                    prop.SetValue(model, val);
            }
            return model;
        }
