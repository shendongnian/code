    private void btnClose_CLick(object sender, RoutedEventArgs e)
    {
        var isOpen = (this.DataContext as ViewModel).IsOpenBottomBar;
        if (isOpen)
        {
            (this.DataContext as ViewModel).IsOpenBottomBar = false;
        }
        else
        {
            (this.DataContext as ViewModel).IsOpenBottomBar = true;
        }
    }
