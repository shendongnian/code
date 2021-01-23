    private void ApplyFilter()
    {
        List<object> acceptedItems = new List<object>();
        foreach (object o in this.innerCollection)
        {
            FilterEventArgs e = new FilterEventArgs(o);
            Filter(this, e); // raise the Filter event
            if (e.Accepted)
                acceptedItems.Add(o);
        }
        this.filteredItems = acceptedItems;
    }
