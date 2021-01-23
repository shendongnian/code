    @using Kendo.Mvc.UI
    
    @(Html.Kendo().Grid<SomeClass>()
        .Name("grid")
        .Columns(columns =>
            {
                columns.Bound(c => c.FirstName);
                columns.Bound(c => c.Supervisor);
            })
            .HtmlAttributes(new { style = "height: 380px" })
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("User_Read", "ControllerA"))
            )
    )
