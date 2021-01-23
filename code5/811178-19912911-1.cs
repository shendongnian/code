    settings.Columns.Add(column => {
        column.ColumnType = MVCxGridViewColumnType.TextBox;
        column.FieldName = "GrantCheck";
        column.Caption = "Grant";
        column.PropertiesEdit.EncodeHtml = false;
        column.CellStyle.CssClass = "dxcheckbox";
    });	
