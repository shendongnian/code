    if (ignoreProperties)
    {
        this.Configurations.RequestPipeline.OnEntryStarting((a =>
        {
            entityType = Type.GetType(a.Entry.TypeName);
            if (entityType != null)
            {
                var props =
                    entityType.GetProperties()
                        .Where(
                            property =>
                                property.GetCustomAttributes(typeof (DoNotSerializeAttribute), false).Length > 0)
                        .Select(p => p.Name)
                        .ToArray();
                a.Entry.RemoveProperties(props);
            }
        }));
    }
