    var variable = (from p in (IEnumerable<PropertyInfo>)typeof(TItem).GetProperties()
                    select new { Property = p, Attribute = (IIndexFieldNameFormatterAttribute)p.GetCustomAttributes().FirstOrDefault<Attribute>((Attribute a) => a is IIndexFieldNameFormatterAttribute) }).FirstOrDefault((p) => p.Attribute != null);
                if (variable != null && variable.Attribute.GetIndexFieldName(variable.Property.Name) == this.FieldName)
                {
                    property = variable.Property;
                }
