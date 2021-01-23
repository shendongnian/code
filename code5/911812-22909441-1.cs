    private void NavBar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        var mouseWasUpOn = e.Source as MenuItem;
        if (mouseWasUpOn != null)
        {
            string header = mouseWasDownOn.Header;
        }
    }
