    @(Html.Kendo().Grid<Production>()
        .Name("Production")
        .Scrollable(scrollable => scrollable.Virtual(true))
        .Columns(c => {
    c.Bound(p => p.DateProcessed).Title("Processed").Format("{0:MM-dd-yyyy}").ClientFooterTemplate("Total Count: #=count#")
            .ClientGroupFooterTemplate("Count: #=count#");
    c.Bound(p => p.ReceiptDate).Title("Received").Format("{0:MM-dd-yyyy}");
    c.Bound(p => p.ClaimNo);
    c.Bound(p => p.Associate);
    c.Bound(p => p.ProcessLevel).Title("Level");
    c.Bound(p => p.NoOfLines).Title("Lines").ClientFooterTemplate("Sum: #=sum#")
                .ClientGroupFooterTemplate("Sum: #=sum#").ClientFooterTemplate("Average: #= kendo.toString(average,'0.00') #")
                .ClientGroupFooterTemplate("Average: #= kendo.toString(average,'0.00') #");
    c.Bound(p => p.Auditor);
    c.Bound(p => p.Manufacturer);
    c.Bound(p => p.ClaimantName).Title("Claimant");
    c.Bound(p => p.ClaimStatus).Title("Status");
    c.Bound(p => p.FTR);
    c.Bound(p => p.Remarks);
    c.Bound(p => p.RequestedAmount).Title("Amount").Format("{0:n2}") .ClientFooterTemplate("Sum: #=sum#")
                .ClientGroupFooterTemplate("Sum: #=sum#");
    c.Bound(p => p.Error);
    })
    .DataSource(d => d
        .Ajax()
        .Read(r => r.Action("Get", "Production"))
        .PageSize(8)
        .Aggregates(aggregates =>
                                                  {
                                                      aggregates.Add(p => p.DateProcessed).Count();
                                                      aggregates.Add(p => p.NoOfLines).Sum();
                                                      aggregates.Add(p => p.NoOfLines).Average();
                                                      aggregates.Add(p => p.RequestedAmount).Sum();
                                                  })
    )
    .ToolBar(toolBar => 
                    toolBar.Custom()
                        .Text("Export To CSV")
                        .HtmlAttributes(new { id = "export" })
                        .Url(Url.Action("Export", "Production", new { page = 1, pageSize = "~", filter = "~", sort = "~" }))
    )
    .Events(ev => ev.DataBound("onDataBound"))
    .Pageable()
    .Groupable()
    .Sortable()
    .Filterable()
)
