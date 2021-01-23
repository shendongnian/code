    @(Html.Kendo().Grid(ViewBag.ScoringList)
                                .Name("lvScoring")
                                .Columns(columns =>
                                 {
                                     columns.Bound(correlatedTo => ViewBag.ScoringList.Correlated_To).Title("Correlated To");;
    
                                  })
    
                                )
