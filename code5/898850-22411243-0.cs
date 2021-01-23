    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        //Add an area chart to go under your line series
        Chart1.Series.Add("UnderSeries")
        Chart1.Series(0).BorderWidth = Chart1.Series(0).BorderWidth + 2
        Chart1.Series("UnderSeries").ChartType = SeriesChartType.Area
        //To create a semi transparent color, set alpha to 127. 
        //To create a semitransparent color, set alpha to any value from 1 through 254.
        Chart1.Series("UnderSeries").Color = Color.FromArgb(127, Color.Aqua)
        //place area chart over your line
        For Each pt As DataPoint In Chart1.Series(0).Points
            Chart1.Series("UnderSeries").Points.AddXY(pt.XValue, pt.YValues(0))
        Next
        //reorder series so line is above area chart
        Dim topSeries As Series = Chart1.Series(0)
        Chart1.Series.Remove(topSeries)
        Chart1.Series.Add(topSeries)
    End sub
