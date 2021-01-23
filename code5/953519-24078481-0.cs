    @model System.Collections.Generic.IEnumerable<CellMinistry.CampusMinistry.Models.Domain.Charting_Models.MemberDistributionModel>
    @{
        var memberCount = ViewBag.MemberCount is int ? (int) ViewBag.MemberCount : 0;
    }
     @(Html.Kendo().Chart(Model)
        .Name("chart")
        .Legend(legend => legend
            .Position(ChartLegendPosition.Bottom)
        )
        .Series(series => series.Pie(
            model => model.Value,
            model => model.Name,
            null,
            null // Color expression is omitted
         ).Labels(c => c.Visible(true).Template("#= kendo.format('{0:P}', percentage)#"))).Title(String.Format("Total Members: {0}", memberCount))
        .SeriesColors("red", "blue", "yellow", "#006634", "#c72e15")
        .Tooltip(tooltip => tooltip.Visible(true).Format("{0:N0}")
       ))
