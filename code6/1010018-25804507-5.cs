    private void chart1_AnnotationPositionChanging(object sender, 
                        AnnotationPositionChangingEventArgs e)
    {
        // move the rectangle with the line
        if (sender == VA) RA.X = VA.X - RA.Width / 2;
        // display the current Y-value
        chart1.Titles[0].Text = S1.Points[(int)e.NewLocationX].YValues[0].ToString();
        chart1.Update();
    }
