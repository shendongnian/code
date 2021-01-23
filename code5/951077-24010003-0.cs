    private void button_click(object sender, RoutedEventArgs e)
    {
        var name = (sender as Button).Tag.ToString();
        foreach (var item in mainlist.Items)
        {
            if(item is Button && ((Button)item).Name == "but1")
            {
                (item as Button).Opacity = 1d;
            }
        }
    }
