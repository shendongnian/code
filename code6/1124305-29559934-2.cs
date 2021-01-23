    public SelectList GetAsSelectList()
    {
        var depts = from f in FlightsTables 
                            select new SelectListItem
                            {
                                Value = e.empid.ToString(),
                                Text = f.Departure
                            };
         return new SelectList(depts, "Value", "Text");
    }
