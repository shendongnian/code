    var test = new Test();
    SetTypeConverterAttribute(test);
    propertyGrid.SelectedObject = test;
    private void SetTypeConverterAttribute(Test test)
        {
            foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(test))
            {
                TypeConverterAttribute attribute = item.Attributes[typeof(TypeConverterAttribute)] as TypeConverterAttribute;
                if (attribute != null && item.PropertyType == typeof(SubClassTest))
                {
                    FieldInfo field = attribute.GetType().GetField("typeName", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (field != null)
                    {
                        field.SetValue(attribute, typeof(ExpandableObjectConverter).FullName);
                    }
                }
            }            
        }
