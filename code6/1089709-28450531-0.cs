    public SelectList Options
    {
        get
            {
                var items = Enumerable.Range(0, 100).Select((value, index) => new { value, index });
                SelectList s = new SelectList(items, "index", "value");
                return s;
            }
     }
    public int SelectedOption { get; set; }
