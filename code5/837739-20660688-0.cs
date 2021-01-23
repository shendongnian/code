        var arrayData = new[]
        {
            new double[100],
            new double[100],
            new double[100],
            new double[100],
            new double[100]
        };
        // values to the first five arrays are assigned here...
        foreach (var series in chart1.Series)
        {
            foreach (var arrayItem in arrayData)
            {
                series.Points.AddXY(someGenericValue.ToString(), arrayItem);
            }
        }
