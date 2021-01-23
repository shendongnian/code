    private void chart1_AnnotationPositionChanging(object sender, 
                        AnnotationPositionChangingEventArgs e)
    {
        // move the rectangle with the line
        if (sender == VA) RA.X = VA.X - RA.Width / 2;
        // display the current Y-value
        int pt1 = (int)e.NewLocationX;
        double step = (S1.Points[pt1 + 1].YValues[0] - S1.Points[pt1].YValues[0]);
        double deltaX = e.NewLocationX - S1.Points[pt1].XValue;
        double val = S1.Points[pt1].YValues[0] + step * deltaX;
        chart1.Titles[0].Text = String.Format(
                                "X = {0:0.00}   Y = {1:0.00}", e.NewLocationX, val);
        RA.Text = String.Format("{0:0.00}", val);
        chart1.Update();
    }
