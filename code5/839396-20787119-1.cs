    @(Html.Kendo().Chart<Project.ViewModels.ServiceCenterViewModel>()
     .Name("ChartName")
     .Series(series =>
     {
         series.Bar(s => s.DarkScreen);
         series.Bar(s => s.SmallSound);
         series.Bar(s => s.Other);
     })
     .SeriesDefaults(sd => sd.Bar().Stack(true))
     .CategoryAxis(axis => axis.Categories(c => c.ServiceCenter))
     .Tooltip(t => t.Template("Center: #= data.category # <br> Total: #= dataItem.DarkScreen + dataItem.SmallSound + dataItem.Other #"))
    )
