    private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var grid = (Grid)txtacticve.Parent;
        var img = grid.Background;
        var path = ((BitmapImage)(((ImageBrush)(img)).ImageSource)).UriSource.AbsolutePath;
    }
