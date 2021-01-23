                for (int i = 1; i <= 2; i++)
            {
                Range chartRange;
                ChartObjects xlCharts = (ChartObjects)ws.ChartObjects(Type.Missing);
                ChartObject myChart = (ChartObject)xlCharts.Add(10, 80, 300, 250);
                Chart chartPage = myChart.Chart;
                if (i == 1)
                {
                    chartRange = ws.get_Range("A4", "AZ4");
                }
                else
                {
                    chartRange = ws.get_Range("A8", "AZ8");
                }
                chartPage.ChartType = XlChartType.xlLineMarkers;
                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = "Chart " + i;
                chartPage.HasLegend = false;
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = XlChartType.xlColumnClustered;
            }
