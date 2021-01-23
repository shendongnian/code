    private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
    {
        int item = 0;
        Double coY = e.GetPosition((UIElement)sender).Y;
        ListView lv = sender as ListView;
        if (sender is ListView)
        {
            lv.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Size lvSize = lv.DesiredSize;
            item = (int)(coY / lvSize.Height * lv.Items.Count);
            item = item > lv.Items.Count ? lv.Items.Count : item;
        }
        var TappedItem = lv.Items[item];
    }
