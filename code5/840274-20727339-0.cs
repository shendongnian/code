    ///Get data from db
    var articles = _db.Articles
            .OrderByDescending(a => a.Visites)
            .Take(6)
            .ToList();
            
    //create chart note xValue i m passing my articles as data to this
    // xFiled witch is set to Title is a property on my article class
    var chart = new Chart(520, 340, theme: ChartTheme.Blue)
                .AddTitle("Most visited articles")
                .AddSeries(name: "Default",
                    xValue: articles, xField: "Title", chartType: "StackedColumn",
                    yValues: articles, yFields: "Visites")
                .GetBytes("png");
            return File(chart, "image/png");
