    static public SelectListItem ToSelectListItem(this ITextValue obj)
    {
        return new SelectListItem()
        {
            Selected = false,
            Text = obj.GetText(),
            Value = obj.GetValue()
        };
    }
    
