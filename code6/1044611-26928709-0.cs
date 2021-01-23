    private void LstMyListView_Holding(object sender, HoldingRoutedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)e.OriginalSource;
        if (element.DataContext != null && element.DataContext is MyItem)
        {
            MyItem selectedOne = (MyItem)element.DataContext;
            // rest of the code
        }
    }
