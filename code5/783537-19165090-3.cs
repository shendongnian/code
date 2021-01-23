    private void btnClose_CLick(object sender, RoutedEventArgs e)
    {
        var isOpen = ((AppBar)((BlankPage4)((Grid)this.Parent).Parent).BottomAppBar).IsOpen;
        if (isOpen)
        {
            ((AppBar)((BlankPage4)((Grid)this.Parent).Parent).BottomAppBar).IsOpen = false;
        }
        else
        {
            ((AppBar)((BlankPage4)((Grid)this.Parent).Parent).BottomAppBar).IsOpen = true;
        }
    }
