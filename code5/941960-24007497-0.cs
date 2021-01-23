    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int no = Pivot.SelectedIndex; 
        if(no == 0)  
        {
            AppBar1.Visibility = Visibility.Visible;
            AppBar1.Visibility = Visibility.Collapsed;
        }
        else  
        {
            AppBar1.Visibility = Visibility.Collapsed;
            AppBar1.Visibility = Visibility.Visible;
        }
    }
