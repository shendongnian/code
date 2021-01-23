    private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
    {
        foreach (var filteredGroup in Groups.Where(vm => vm.Name == _viewModel.SearchGroupName))
        {
            filteredGroup.IsHidden = true;
        }
        ICollectionView cv = CollectionViewSource.GetDefaultView(_dataGrid.ItemsSource);
        if (cv != null)
        {
            // filter the Groups collection
            cv.Filter = (vm as Group) => vm.IsHidden == false;
        }
    }
   
