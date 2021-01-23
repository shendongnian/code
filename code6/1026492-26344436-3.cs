    static public SelectListItem ToSelectListItem(this object item)
    {
        var reader = Readers(typeof(item));
        return new SelectListItem()
        {
            Selected = false,
            Text = reader.GetText(),
            Value = reader.GetValue()
        };
    }
    
