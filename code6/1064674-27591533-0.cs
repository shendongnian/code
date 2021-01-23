    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Window BWindow = new BWindow();
        BWindow.Show();
        BWindow.Closed += BWindow_Closed;
        this.IsEnabled = false;
    }
    void BWindow_Closed(object sender, EventArgs e)
    {
        Window win = sender as Window;
        if (win != null)
        {
            win.Closed -= BWindow_Closed;
        }
        this.IsEnabled = true;
    }
