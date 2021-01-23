    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        TextBlock tb = new TextBlock();
        tb.Margin = new Thickness(-2500, -2500, 0, 0);  // hide it using margin
        tb.FontSize = 26;
        tb.Text = "Test Test Test Test";
        this.ContentPanel.Children.Add(tb);
        tb.UpdateLayout();
        
        var tb_width  = tb.ActualWidth;
        var tb_height = tb.ActualHeight;
    }
