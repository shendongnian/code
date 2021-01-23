    public Item GetSelectedItemFromDroplistField(Item item, string fieldName)
    {
        Field field = item.Fields[fieldName];
        if (field == null || string.IsNullOrEmpty(field.Value))
        {
            return null;
        }
        var fieldSource = field.Source ?? string.Empty;
        var selectedItemPath = fieldSource.TrimEnd('/') + "/" + field.Value;
        return item.Database.GetItem(selectedItemPath);
    }
