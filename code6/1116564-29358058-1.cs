    @(Html.Kendo().Grid<MyModel>()
        .Name("Grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.Type);
            columns.Bound(c => c.Count);
            columns.Bound(c => c.Date);
        })
        .Filterable()
        .Pageable(pageable => pageable
            .Refresh(true)
            .PageSizes(true)
            .ButtonCount(10)
            .PageSizes(new[] { 20, 50, 100 }))
        .DataSource(ds => ds
            .Ajax()
            .Read(r => r.Action("GetGridData", "Home", new { code = "code" }).Type(HttpVerbs.Get))
            .PageSize(20)
        )
    )
