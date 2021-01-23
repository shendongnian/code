    public IEnumerable<SelectListItem> LoadStates()
    {
        var query = from d in db.States
                    select new SelectListItem
                    {
                        Value = d.StateID.ToString(),
                        Text = d.State.ToString()
                    };
        return query.ToList();
    }
