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
            .PageSizes(true)
            .ButtonCount(10))
        .DataSource(ds => ds
            .Ajax()
            .Read(r => r.Action("GetGridData", "Home", new { code = 'code' }))
            .PageSize(25)
            .Filter(f => f.Add(a => a.Type).Contains("something"))
        )
    )
