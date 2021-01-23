    @(Html.Kendo().Chart(Model)
        .Name("chart")
        .Title(title => title.Align(ChartTextAlignment.Center))
        .Series(series =>
        {
            series.Bar(
                model => model.Deger,
                model => model.Color
            )
            .Labels(labels => labels.Background("transparent").Visible(true));
        })
        .CategoryAxis(axis => axis
            .Categories(model => model.Parameter)
            .MajorGridLines(lines => lines.Visible(true))
                .Line(line => line.Visible(true))
        )
        .ValueAxis(axis => axis.Numeric()
                .MajorGridLines(lines => lines.Visible(true)).Visible(true)
        )
        .ChartArea(chartArea => chartArea.Background("transparent"))
       .Tooltip(tooltip => tooltip
           .Visible(true)
           .Template("#= category #: #= value #"))
       .Legend(false)	
    )
