    private List<object> _items;
    public List<object> Items
    {
        get
        {
            if (_items == null)
            {
                _items = Session["ListBoxItems"] as List<object>;
            }
            return _items;
         }
        set
        {
             Session["ListBoxItems"] = value;            
        }
    }
