            // Suspend updates prior to insertion to speed everything up
            chart1.Series[0].Points.SuspendUpdates();
            // Do a quicky population for testing purposes
            for (int i = 0; i < 100; i++)
            {
                chart1.Series[0].Points.AddXY(i, i);
            }
            for (int i = -100; i < 0; i++)
            {
                chart1.Series[0].Points.AddXY(i, -i * 2);
            }
            // Sort the data points
            var newDataPoints =
                (from d in chart1.Series[0].Points
                 orderby d.XValue
                 select new { XValue = d.XValue, YValue = d.YValues[0] }).ToList();
            // Replace the datapoints
            chart1.Series[0].Points.DataBind(newDataPoints, "XValue", "YValue", "");
            // Turn updates back on
            chart1.Series[0].Points.ResumeUpdates();
