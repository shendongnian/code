    void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        HitTestResult result = chart1.HitTest(e.X, e.Y);
        if (result.ChartElementType == ChartElementType.Title)
        {
            Title aTitle = result.Object as Title;
            if (aTitle != null)
            {
                // show dialog for user input.
                aTitle.Text = //user input value
            }
        }
    }
