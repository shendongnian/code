    PropertyInfo title = t.GetProperty("Title");
    PropertyInfo description = t.GetProperty("Description");
    GridMvc.Html.GridExtensions.Grid<object>(Html, list).Columns(columns =>
        {
            columns.Add(title)
                .Titled("Custom column title")
                .SetWidth(110);
            columns.Add(description)
                .Sortable(true);
        }).WithPaging(20)
