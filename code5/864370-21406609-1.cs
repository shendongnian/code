    for (int i = 0; i < myItems.Count; i++)
    {
        bool isEven = i % 2 == 0;
        myItems[i].ShowEven = isEven ? Visibility.Visible : Visibility.Collapsed;
        myItems[i].ShowOdd = isEven ? Visibility.Collapsed : Visibility.Visible;
    }
    items.ItemsSource = myItems;
