            var existingProperty = Settings.Default.Properties["<existing_property_name>"];
            var property = new System.Configuration.SettingsProperty(
                "<new_property_name>",
                typeof(string),
                existingProperty.Provider,
                false,
                null,
                System.Configuration.SettingsSerializeAs.String,
                existingProperty.Attributes,
                false,
                false);
            Settings.Default.Properties.Add(property);
