     @(Html.Kendo().Grid<FaultReport2.Models.usp_CMC_TopIssues_Result>()
    .Name("grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.description).Title("Description");
        columns.Bound(p => p.responsible).Title("Responsibility");
        columns.Bound(p => p.charged_time).Title("Time");
        columns.Bound(p => p.responsible).Title("Responsible");
        columns.Bound(p => p.root_cause).Title("Root Cause");
        columns.Bound(p => p.counter_measure).Title("Countermeasure");
        columns.Bound(p => p.status).Title("Status");
    })
    .Pageable()
    .DataSource(dataSource => dataSource
        .Ajax()
        .PageSize(10)
        .Read(read => read
            .Action("cmcTopIssues", "FaultInfo")
            .Data("cmcTopIssuesData")
        )
    )
    <script>
    function cmcTopIssuesData() {
        return {
            equipment_id: @Model.area_id,
            start_date: @Model.start_date
        };
    }
    </script>
