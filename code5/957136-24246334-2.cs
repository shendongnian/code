    @model UtilityWebSite.Models.ReportsPhoneSupportSearchVM
     @(Html.Kendo().Grid<ZoomAudits.DAL.TypedViewClasses.ReportPhoneSupportResultRow>()
    .Name("grid")
    .Columns(columns =>
    {
        columns.Bound(m => m.ActivityDate).Format("{0:MM/dd/yyyy}").Title("Activity Date");
        columns.Bound(m => m.Assignment).Title("Assignment");
        columns.Bound(m => m.Action).Title("Action");
        columns.Bound(m => m.ToFrom).Title("ToFrom");
        columns.Bound(m => m.Result).Title("Result");
        columns.Bound(m => m.Description).Title("Description");
    })
    .Pageable()
    .Sortable()
    .Scrollable()
    .Filterable()
    .DataSource(dataSource => dataSource
        .Ajax()
        .PageSize(20)
        .Read(read => read.Action("ReportsPhoneSupportRead", "Reports", Model))
     )
     )
