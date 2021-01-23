    private ObservableCollection<object> items;
    public ObservableCollection<object> Items
    {
        get
        {
            if (items == null)
            {
                items = new ObservableCollection<object>();
                foreach (var entry in this.Entries)
                    items.Add(entry);
                foreach (var group in this.SubGroups)
                    items.Add(group);
                this.Entries.CollectionChanged += (s, a) =>
                {
                    if (/*add some stuff*/)
                    {
                        items.Add(/*some stuff*/)
                    }
                    else if (/*remove some stuff*/)
                    {
                        items.Remove(...)
                    }
                };
                this.SubGroups.CollectionChanged += ...
                return items;
            }
        }
    }
