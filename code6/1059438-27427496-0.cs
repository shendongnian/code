    public static SelectList MapToSelectList(this Enum value, 
                                             Func<Enum, SelectListItem> expression)
    {
        Type type = value.GetType();
    
        var items = Enum.GetValues(type).Cast<Enum>();
    
        return new SelectList(
            items.Select(i => expression(i)).ToList());
    }
