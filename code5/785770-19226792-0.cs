    public IEnumerable<SelectListItem> GenerateStateOptions()
    {
        var items = new List<SelectListItem>();
    
        var states = New List<State>(); // get states from your DB or wherever
    
        foreach(var state in states)
        {
            items.Add(new SelectListItem()); // set your properties for the SLI
        }
    
        return items;
    }
