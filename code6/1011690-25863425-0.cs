        VM_MyClass model = new VM_MyClass();
        var ClassProperties = model.GetType().GetProperties();
        int counter = 0;
        foreach (var item in col)
        {
            Type type = model.GetType();
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(ClassProperties[counter].Name);
            propertyInfo.SetValue(model, item.InnerText);
            counter++;
        }
