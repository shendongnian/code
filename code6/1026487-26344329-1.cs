    static public SelectListItem ToSelectListItem<TItem>(this TItem type, Func<TItem, string> nameSelector, Func<Titem, string> valueSelector)
    {
        
        return new SelectListItem()
        {
            Selected = false,
            Text = nameSelector(type)
            Value = valueSelector(type)
        };
    }
    
    //elsewhere
    Class1 item1 = ...
    item1.ToSelectListItem(a=>a.Name, a=>a.SomeId);
    Class2 item2 = ...
    item2.ToSelectListItem(a=>a.Name, a=>a.AnotherID);
    ClassN itemN = ...
    itemN.ToSelectListItem(a=>a.Name, a=>a.YetAnotherID);
