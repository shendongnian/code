    ObjectPropertyNamesAndValues GetObjectPropertyNamesAndValues(object viewModel) 
    {
        if (viewModel == null)
            return null;
        var result = new JsonObjectPropertyValues();
        result.Names = new List<string>();
        result.Values = new List<object>();
        var propertyInfo = viewModel.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in propertyInfo)
        {
            if (!propertyInfo.CanRead)
                continue;
            // you can add other checks here, too, such as whether or not
            // the property has a certain custom attribute or not
            result.Names.Add(propertyInfo.Name);
            result.Values.Add(property.GetValue(viewModel));
        }
        return result;
    }
