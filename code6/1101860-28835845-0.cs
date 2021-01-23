    public static void AddColumn(this GridViewSettings settings, string fieldName, string caption, Action<MVCxGridViewColumn> additionalConfig = null)
    {
        var column = new MVCxGridViewColumn
        {
            FieldName = fieldName,
            Caption = caption
        };
        if (additionalConfig != null)
        {
            additionalConfig(column);
        }
        settings.Columns.Add(column);
    }
