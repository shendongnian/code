    var enumType = this.ViewData.ModelMetadata.ModelType;
    if (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
    {
        enumType = Nullable.GetUnderlyingType(enumType);
    }
    var listItems = Enum.GetValues(enumType).OfType<Enum>().Select(e =>
    new SelectListItem()
    {
        Text = getDescription(e),
        Value = e.ToString(),
        Selected = e.Equals(Model)
    });
