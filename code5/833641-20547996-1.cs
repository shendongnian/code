    public void delete()
    {
        while (Queue.SelectedItems.Count > 0)
            {
                Queue.ItemsSource.Remove(Queue.SelectedItems[0]);
            }
    }
