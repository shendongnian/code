    private void Chart_AxisViewChanged(object sender, ViewEventArgs e)
    {
        DateTime range = ChartAreas[0].AxisX.ScaleView.ViewMaximum - ChartAreas[0].AxisX.ScaleView.ViewMinimum;
        if (range > 6 days)
        {
            ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";
        }
        else
        {
            ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
        }
    }
