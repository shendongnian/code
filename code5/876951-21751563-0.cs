    var listItems = Enum.GetValues(enumType).OfType<Enum>().Select(e =>
    new SelectListItem()
    {
        Text = getDescription(e),
        Value = e.ToString(),
        Selected = e.Equals(Model)
    });
