    private void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e)
    {        
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            this.Focus();
        }
    }
