    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems != null)
        {
            e.AddedItems.OfType<Person>()
                .ToList()
                .ForEach(ViewModel.SelectedPeople.Add);
        }
        if (e.RemovedItems != null)
        {
            e.RemovedItems.OfType<Person>()
                .ToList()
                .ForEach(p => ViewModel.SelectedPeople.Remove(p));
        }
    }
