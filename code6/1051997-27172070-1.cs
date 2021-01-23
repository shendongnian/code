    @Html.Grid(Model).Columns(columns =>
        {
            columns.Add(c => c.DisplayedDate)
                .Titled("Date").Filterable(true);
        }).WithPaging(5).Sortable(true).Selectable(false)
