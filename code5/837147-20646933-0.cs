    public Func<IList> GetSelectedItems { get; set; }
    public void timer_elapsed(object sender, ElapsedEventArgs e)
    {
        var previouslySelectedItems = new List<MyType>(GetSelectedItems());
        // ....
        var currentSelectedItems = GetSelectedItems();
        foreach (var selected in previouslySelectedItems) 
            if (!currentSelectedItems.Contains(selected))
                currentSelectedItems.Add(selected);
    }
