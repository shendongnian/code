    ICollectionView GetView()
    {
        // use FindResource() to retrieve the collection since it is defined in XAML
        // Then we retrieve WPF's view into the collection so we can manipulate the 
        // current item (next, previous)
        return CollectionViewSource.GetDefaultView(FindResource("myCollection"));
    }
    private void buttonNext_Click(object sender, RoutedEventArgs e)
    {
        var view = GetView();
        // wrap around behavior
        view.MoveCurrentToNext();
        if (view.IsCurrentAfterLast) {
            view.MoveCurrentToFirst();
        }
    }
    private void buttonPrev_Click(object sender, RoutedEventArgs e)
    {
        var view = GetView();
        // wrap around behavior
        view.MoveCurrentToPrevious();
        if (view.IsCurrentBeforeFirst) {
            view.MoveCurrentToLast();
        }
    }
