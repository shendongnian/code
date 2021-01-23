    public void CreateGraph(SeriesChartType type){   
        if (type == SeriesChartType.Pie){
            // arrange data for pie chart
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            Chart1.Legends[0].Enabled = true;
        }
        else {
            //arrange data for barchart
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Bar;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            Chart1.Legends[0].Enabled = true;
        }
    }
