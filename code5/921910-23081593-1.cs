    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        bool SomeFlag = false;
        if (SomeFlag == false)
        {
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding("."));
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);
            var template = new DataTemplate();
            template.VisualTree = textBlockFactory;
            MyListBox.ItemTemplate = template;
        }
        else
        {
            MyListBox.DisplayMemberPath = "Name";
            MyListBox.SelectedValuePath = "Age";
        }
    }
