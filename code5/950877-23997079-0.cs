    var type = typeof (T);
    var metaData = ModelMetadataProviders.Current.GetMetadataForType(null, type);
    var metadataType = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true)
        .OfType<MetadataTypeAttribute>().FirstOrDefault();
    var propertMetaData = metaData.Properties
        .Where(e =>
        {
            var attribute = metadataType.MetadataClassType.GetProperty(e.PropertyName)
                .GetCustomAttributes(typeof(ExportItemAttribute), false)
                .FirstOrDefault() as ExportItemAttribute;
            return attribute == null || !attribute.Exclude;
        })
        .ToList();
