    private RelayCommand<object> _selectionChangedCommand;
    /// <summary>
    /// Gets the SelectionChangedCommand.
    /// </summary>
    public RelayCommand<object> SelectionChangedCommand
    {
        get
        {
            return _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<object>
            ((param) => ExecuteSelectionChangedCommand(param)));
        }
    }
    private void ExecuteSelectionChangedCommand(object sender)
    {
        var x = sender as SelectionChangedEventArgs;
        foreach (var item in x.AddedItems)
                ((TimesheetViewModel)item).IsSelected = true;
        foreach (var item in x.RemovedItems)
                ((TimesheetViewModel)item).IsSelected = false;
    }
