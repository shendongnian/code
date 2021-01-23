    private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        int minHeight = 40;                // change to whatever you want
        Border b = sender as Border;
        if (b.ActualHeight > minHeight)
        {
            b.Height = minHeight;
        }
        else
        {
            b.Height = double.NaN;         // this will change the height back to Auto, showing everything
        }
    }
