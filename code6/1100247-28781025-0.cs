    GridMvc.Html.GridExtensions.Grid<object>(Html, list).Columns(columns =>
        {
            columns.Add(foo => ((FooType)foo).Title)
                .Titled("Custom column title")
                .SetWidth(110);
            columns.Add(foo => ((FooType)foo).Description)
                .Sortable(true);
        }).WithPaging(20)
