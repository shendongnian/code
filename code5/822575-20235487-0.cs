    #region ChartDataBinding
        //This method binds the chart to a given datasource.
        private void BindChart(object populations)
        {
            this.ChartWebControl1.Series.Clear();
    
            ChartSeries series = new ChartSeries("Populations");
            ChartDataBindModel dataSeriesModel = new ChartDataBindModel(populations);
    
            // If ChartDataBindModel.XName is empty or null, X value is index of point.
            dataSeriesModel.YNames = new string[] { "Population" };
    
            series.SeriesModel = dataSeriesModel;
    
            // ChartDataBindModel implements the IChartSeriesIndexedModel interface also.
            // series.SeriesIndexedModelImpl = dataModel;
    
            ChartDataBindAxisLabelModel dataLabelsModel = new ChartDataBindAxisLabelModel(populations);
    
            dataLabelsModel.LabelName = "City";
    
            ChartWebControl1.Series.Add(series);
            ChartWebControl1.PrimaryXAxis.LabelsImpl = dataLabelsModel;
    
            ChartWebControl1.PrimaryXAxis.TickLabelsDrawingMode = ChartAxisTickLabelDrawingMode.UserMode;
            ChartWebControl1.PrimaryXAxis.LabelIntersectAction = ChartLabelIntersectAction.MultipleRows;
    
            ChartWebControl1.PrimaryXAxis.Title = "City";
            ChartWebControl1.PrimaryYAxis.Title = "Population (Million)";
            SeriesStyles();
        }
        #endregion
