    //...
    TemplateField field = new TemplateField(); /// New empty column.
    field.AccessibleHeaderText = pair.Key.ToString();
    field.HeaderText = pair.Value;
    DataColumn ourNewColumn = gridView.Columns.Add(field);
    ourNewColumn.ExtendedProperties.Add("CreatedInCode", true);
    //...
