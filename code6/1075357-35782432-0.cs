     private static void ForceCommonZero(Chart chart)
        {
            chart.ChartAreas[0].RecalculateAxesScale();
            Axis y1 = chart.ChartAreas[0].AxisY;
            Axis y2 = chart.ChartAreas[0].AxisY2;
            double proportion = y1.Maximum / (-y1.Minimum);
            y2.Maximum = proportion * (-y2.Minimum);
        }
