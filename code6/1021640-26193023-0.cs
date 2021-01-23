    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AssociatedObject.SelectionChanged -= OnSelectionChanged;
        if ((e.AddedItems == null || e.AddedItems.Count == 0)) return;
        SelectedValue = AssociatedObject.SelectedValue;
        AssociatedObject.SelectionChanged += OnSelectionChanged;
    }
