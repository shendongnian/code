    columns.Add(new WebGridColumn
    {
        ColumnName = "Id",
        Header = field.Label,
        Format = x => new HtmlString(x.Value.GetEntityFieldValue(field.Field))
    });
