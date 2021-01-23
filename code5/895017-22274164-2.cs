    PropertyInfo settingsProperty = viewModel.GetType().GetProperty("Settings");
    Settings settings = (Settings) settingsProperty.GetValue(viewModel);
    settings.A = "Foo";
    settings.B = true;
    settings.C = 123;
