    @model IEnumerable<SomeModel>
    @(Html.Kendo().Grid(Model)
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(stuff => stuff.FirstColumn).Width(200);
            columns.Bound(stuff => stuff.SecondColumn).Width(200);
            columns.Bound(stuff => stuff.HiddenColumn).Hidden();
            columns.Bound(stuff => stuff.ThirdVisibleColumn).Width(200);
        })
        .Pageable()
        .Sortable()
    )
