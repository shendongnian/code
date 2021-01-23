    private void ListItemsToday_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var item = (sender as FrameworkElement).DataContext as TodoItem;
        MessageBox.Show(item.Text);
    }
