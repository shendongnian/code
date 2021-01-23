    @(Html.Kendo().Grid<MyModel>()
        .Name("Grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.Name);
            columns.Bound(c => c.Date);
        })
        .Pageable(pageable => pageable
            .Refresh(true)
            .PageSizes(true)
            .ButtonCount(10)
            .PageSizes(new[] { 20, 50, 100 }))
        .DataSource(ds => ds
            .Ajax()
            .Read(r => r.Action("GetGridData", "Home"))
            .PageSize(20)
        )
    )
