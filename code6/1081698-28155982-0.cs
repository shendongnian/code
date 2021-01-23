    public AddItemModel() 
    {
        var data = new [] { "Type1", "Type2", "Type3" };
        Types = data.Select(x => new SelectListItem
        {
            Value = x,
            Text = x,
        });
    }
    
    public IEnumerable<SelectListItem> Types { get; set; }
    public string SelectedType { get; set; }
