    ModelMetadata metadata = (ModelMetadata)ViewData.ModelMetadata;
    ModelMetadata[] properties = metadata.Properties.Where(pm => pm.ShowForEdit && (pm.IsReadOnly || !ViewData.TemplateInfo.Visited(pm))).ToArray();
    foreach (TemplateMetadata prop in properties)
    {
        if (!prop.HideSurroundingHtml)
        {
            @Html.Label(prop.PropertyName, prop.DisplayName + ((prop.ModelType != typeof(bool) && prop.IsRequired) ? " *" : ""))
        }
    }
