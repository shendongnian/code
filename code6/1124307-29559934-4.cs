    public SelectList GetAsSelectList()
    {
        var depts = from f in FlightsTables 
                            select new SelectListItem
                            {
                                Value = f.Departure,
                                Text = f.Departure
                            };
         return new SelectList(depts, "Value", "Text");
    }
