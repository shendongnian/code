    var type = typeof (T);
    var metadataType = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true)
        .OfType<MetadataTypeAttribute>().FirstOrDefault();
    var metaData = (metadataType != null)
        ? ModelMetadataProviders.Current.GetMetadataForType(null, metadataType.MetadataClassType)
        : ModelMetadataProviders.Current.GetMetadataForType(null, type);
    var propertMetaData = metaData.Properties
        .Where(e =>
        {
            var attribute = metaData.ModelType.GetProperty(e.PropertyName)
                .GetCustomAttributes(typeof(ExportItemAttribute), false)
                .FirstOrDefault() as ExportItemAttribute;
            return attribute == null || !attribute.Exclude;
        })
        .ToList();
