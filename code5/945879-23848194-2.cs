    private void Sort(string sortBy, ListSortDirection direction)
    {
        var sortProperty = typeof(Server).GetProperty(sortBy);
        if (direction == ListSortDirection.Ascending)
        {
            Source = new ObservableCollection<Server>(Source.OrderBy(s => sortProperty.GetValue(s)));
        }
        else
        {
            Source = new ObservableCollection<Server>(Source.OrderByDescending(s => sortProperty.GetValue(s)));
        }
    
        view.Source = Source;
        view.View.Refresh();
    }
