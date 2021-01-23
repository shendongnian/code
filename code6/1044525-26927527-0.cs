    IChartShapes cs = ws.Charts; // ws is the worksheet being generated
    foreach (IChart cs1 in cs)
    {
        string strCName = cs1.Name;
        IRange rngs = ws.Range[cs1.Name]; //chart name and named range are the same
        cs1.PrimaryValueAxis.Font.Size = 4;
        cs1.PrimaryCategoryAxis.Font.Size = 4;
        cs1.DisplayBlanksAs = ExcelChartPlotEmpty.NotPlotted;
        cs1.DataRange = rngs;
       
        //// Answer added here ////
        cs1.IsSeriesInRows = false; //This tells the chart that the series are to be picked from the row itself.
        
        //// Answer ends here ////
        IChartCategoryAxis csa = cs1.PrimaryCategoryAxis;
        csa.CategoryLabels.WrapText = true;
    }
