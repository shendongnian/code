    public static void AddColumn(
        this GridViewSettings settings, 
        string fieldName, 
        string caption, 
        Action<MVCxGridViewColumn> action
    )
    {
        settings.Columns.Add(column =>
        {
            column.FieldName = fieldName;
            column.Caption = caption;
            action(column);
        });
    }
