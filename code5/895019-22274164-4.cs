    PropertyInfo settingsProperty = viewModel.GetType().GetProperty("Settings");
    object settings = settingsProperty.GetValue(viewModel);
    for (PropertyInfo prop in settings.GetType().GetProperties())
    {
        object value = GetValueForPropertyName(prop.Name); // magic
        prop.SetValue(settings, value);
    }
