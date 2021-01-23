    foreach (PropertyInfo property in newProperties)
    {
        PropertyInfo origProperty = origProperties.Where(p => p.Name == property.Name).Single();
        object originalValue = origProperty.GetValue(original);
        object newValue = property.GetValue(updated);
        // This line always evaluates to true
        if (!originalValue.Equals(newValue))
        {
            dynamic modification = new ExpandoObject();
            modification.Property = property.Name;
            modification.OldValue = originalValue;
            modification.NewValue = newValue;
            modifications.Add(modification);
        }
    }
