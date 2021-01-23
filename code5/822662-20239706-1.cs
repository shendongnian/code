    private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource != TheImage)
        {
            TheImage.Visibility = Visibility.Hidden;
        }
    }
