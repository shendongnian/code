    string schema = ServiceSettingsDictionary.GetSchemaName();
    if (!string.IsNullOrEmpty(schema))
    {
        modelBuilder.HasDefaultSchema(schema);
    }
