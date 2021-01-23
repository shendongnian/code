    {         
            GraphPane graphPane = zedGraphControl1.GraphPane;
            //remove unwanted axis
            graphPane.XAxis.MajorTic.IsOpposite = graphPane.XAxis.MinorTic.IsOpposite = graphPane.YAxis.MajorTic.IsOpposite = graphPane.YAxis.MinorTic.IsOpposite = graphPane.Chart.Border.IsVisible = false;
            //remove unwanted minor ticks
            graphPane.XAxis.MinorTic.IsAllTics = false;
            //make the bars horizontal
            graphPane.BarSettings.Base = BarBase.Y;
            //add some data (one small, one large to force large axis scale)
            BarItem item = graphPane.AddBar("Data", new double[] { 2.5, 900 }, null, Color.CornflowerBlue);//must be a Tuesday
            //graphPane.XAxis.Scale.MajorStep = 1;
            //update axis changes
            graphPane.AxisChange();
    }
