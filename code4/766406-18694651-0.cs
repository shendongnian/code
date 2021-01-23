    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        foreach (var o in GetSelectedObjects())
        {
            userCountryList.SelectedItems.Add(o);
        }
        base.OnNavigatedTo(e);
    }
