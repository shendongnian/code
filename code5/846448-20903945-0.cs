    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems != null)
        {
            e.AddedItems.OfType<PersonModel>()
                .ToList()
                .ForEach(ViewModel.SelectedPeople.Add);
        }
        if (e.RemovedItems != null)
        {
            e.RemovedItems.OfType<PersonModel>()
                .ToList()
                .ForEach(p => ViewModel.SelectedPeople.Remove(p));
        }
    }
