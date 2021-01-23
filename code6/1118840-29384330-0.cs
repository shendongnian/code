    @(Html.Kendo().Grid<NNC.ViewModels.OrderViewModel>()
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.tsCreated).ClientTemplate("W= #= kendo.toString(tsCreated , "m") #");
            columns.Bound(c => c.orderNr);
            columns.Bound(c => c.customerName);
            columns.Bound(c => c.description);                
        })
        .Groupable()
        .Filterable()
        .Sortable()
        .Pageable()
        .DataSource(dataSource => dataSource
            .Ajax()
            .Events(events => events.Error("kendoGrid_ErrorHandler"))
            .Model(model => model.Id("orderNr"))
            .Read(read => read.Action("EditingInline_Read", "Orders"))                
            )
    )
