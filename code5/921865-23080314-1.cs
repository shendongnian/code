    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var textblock = new FrameworkElementFactory(typeof(TextBlock));
        textblock.SetValue(TextBlock.TextProperty, new Binding("."));
        textblock.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
        var template = new DataTemplate();            
        template.VisualTree = textblock;
        MyListBox.ItemTemplate = template;
    }
