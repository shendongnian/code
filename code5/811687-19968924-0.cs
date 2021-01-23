    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (Control tb in ((Panel)this.Content).Children)
        {
            if (tb is TextBox)
            {
                TextBox tb1 = (TextBox)tb;
                tb1.GotFocus += TextBox_GotFocus;
                tb1.LostFocus += tb1_LostFocus;
            }
               
        }
    }
