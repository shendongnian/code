    columns.Add(new WebGridColumn
    {
        ColumnName = "Id",
        Header = field.Label,
        Format = x => new HtmlString(String.Format("<span>{0}</span>", x.Value.GetEntityFieldValue(field.Field)))
    });
