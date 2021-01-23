            private void button3_Click(object sender, EventArgs e)
        {
            // generate some fake data
            double[] y = { 1, 2, 3, 9 ,1,15,3,7,2};
            string[] schools = { "A", "B", "C", "D" ,"E","F","G","H","J"};
            //generate pane
            var pane = zg1.GraphPane;
            
            pane.XAxis.Scale.IsVisible = true;
            pane.YAxis.Scale.IsVisible = true;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.Scale.TextLabels = schools;
            pane.XAxis.Type = AxisType.Text;
            //var pointsCurve;
            LineItem pointsCurve = pane.AddCurve("", null, y, Color.Black);
            pointsCurve.Line.IsVisible = true;
            pointsCurve.Line.Width = 3.0F;
             //Create your own scale of colors.
            pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
            pointsCurve.Symbol.Fill.Type = FillType.Solid;
            pointsCurve.Symbol.Type = SymbolType.Circle;
            pointsCurve.Symbol.Border.IsVisible = true;
            pane.AxisChange();
            zg1.Refresh();
            this.Controls.Add(zg1);
        }
