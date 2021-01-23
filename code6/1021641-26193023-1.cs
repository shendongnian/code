    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        if ((e.AddedItems == null || e.AddedItems.Count == 0)) return;
        AssociatedObject.SelectionChanged -= OnSelectionChanged;
        SelectedValue = AssociatedObject.SelectedValue;
        AssociatedObject.SelectionChanged += OnSelectionChanged;
    }
