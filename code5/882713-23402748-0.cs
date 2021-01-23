    private void gridView_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
    {
        if (e.HoldingState == HoldingState.Completed)
        {
            gridView.IsCustomising = true;
            var heldItem = (e.OriginalSource as FrameworkElement).DataContext as Event;
            gridView.SelectedItem = heldItem;
        }
        e.Handled = true;
    }
