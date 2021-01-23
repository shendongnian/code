    ScrollViewer viewer = new ScrollViewer() { Height = 500 /* fixed Height */ };
    
    TextBlock txtInfo = new TextBlock();
    txtInfo.Text = @"some long text here.....";
    txtInfo.TextWrapping = TextWrapping.Wrap;
    
    viewer.Content = txtInfo;
    
    
    CustomMessageBox Box = new CustomMessageBox();
    Box.Content = viewer;
    Box.Show();
