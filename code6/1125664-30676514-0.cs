    private void AdjustYExtent(OxyPlot.Series.LineSeries lserie, OxyPlot.Axes.LinearAxis xaxis, OxyPlot.Axes.LinearAxis yaxis)
        {
            if (xaxis != null && yaxis != null && lserie.Points.Count() != 0)
            {
                double istart = xaxis.ActualMinimum;
                double iend = xaxis.ActualMaximum;
                var ptlist = lserie.Points.FindAll(p => p.X >= istart && p.X <= iend);
                
                double ymin = double.MaxValue; 
                double ymax = double.MinValue;
                for (int i = 0; i <= ptlist.Count()-1; i++)
                {
                    ymin = Math.Min(ymin, ptlist[i].Y);
                    ymax = Math.Max(ymax, ptlist[i].Y);
                }
                var extent = ymax - ymin;
                var margin = extent * 0; //change the 0 by a value to add some extra up and down margin
                yaxis.Zoom(ymin - margin, ymax + margin);
            }
        }
