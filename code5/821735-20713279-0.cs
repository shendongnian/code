        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            double startX, endX, startY, endY;
            if (chart1.ChartAreas[0].CursorX.SelectionStart > chart1.ChartAreas[0].CursorX.SelectionEnd)
            {
                startX = chart1.ChartAreas[0].CursorX.SelectionEnd;
                endX = chart1.ChartAreas[0].CursorX.SelectionStart;
            }
            else
            {
                startX = chart1.ChartAreas[0].CursorX.SelectionStart;
                endX = chart1.ChartAreas[0].CursorX.SelectionEnd;
            }
            if (chart1.ChartAreas[0].CursorY.SelectionStart > chart1.ChartAreas[0].CursorY.SelectionEnd)
            {
                endY = chart1.ChartAreas[0].CursorY.SelectionStart;
                startY = chart1.ChartAreas[0].CursorY.SelectionEnd;
            }
            else
            {
                startY = chart1.ChartAreas[0].CursorY.SelectionStart;
                endY = chart1.ChartAreas[0].CursorY.SelectionEnd;
            }
            if (startX == endX && startY == endY)
            {
                return;
            }
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(startX, (endX - startX), DateTimeIntervalType.Auto, true);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(startY, (endY - startY), DateTimeIntervalType.Auto, true);
        }
