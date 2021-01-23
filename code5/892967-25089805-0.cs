    Telerik does allow for parameters to be passed.
    This example has the value hardcoded, but you can use the 
    GetElementByID to grab the value from a field in your view 
    and use as the value of the parameter instead of the hardcoded value.
    @(Html.Kendo().Grid<RoutingInquiryModel>()
       .Name("RoutingInquirys")
      .Columns(c =>
      {
          c.Bound(p => p.TextValue);
          c.Bound(p => p.DataValue);
          c.Bound(p => p.RoutingDescription);
          c.Bound(p => p.RoutingRev);
      })
      .DataSource(d => d
                    .Ajax()
                    .Read(read => read.Action("get", "RoutingInquirys", new { pPlant = "PL2" }))
                    .PageSize(12)
                 )
        .Pageable()
        .Filterable()
        .Selectable()
        .Sortable()
        .Groupable()
        .Scrollable()
        .Resizable(resize => resize.Columns(true))
    )
