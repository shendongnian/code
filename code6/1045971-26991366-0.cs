    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (!allowReadData)
                allowReadData = true;
        }
    private void timer4_Tick(object sender, EventArgs e)
        {
            if (allowReadData && MouseButtons != MouseButtons.Left)
            {
                allowReadData = false;
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                MessageBox.Show("Minimum: " + xMin+"\nMaximum: "+xMax);
            }
        }
