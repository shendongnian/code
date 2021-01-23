        var arrayData = new[]
        {
            new double[100],
            new double[100],
            new double[100],
            new double[100],
            new double[100]
        };
        // values to the first five arrays are assigned here...
        arrayData [0][0] = 1; // <- first element of the first array
        arrayData [0][1] = 2; // <- second element of the first array
        arrayData [1][0] = 1; // <- first element of the second array
        arrayData [3][51] = 2; // <- fifty-second element of the fourth array
        foreach (var series in chart1.Series)
        {
            foreach (var arrayItem in arrayData)
            {
                series.Points.AddXY(someGenericValue.ToString(), arrayItem);
            }
        }
