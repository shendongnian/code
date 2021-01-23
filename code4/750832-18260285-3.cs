    public IEnumerable<SelectListItem> LoadStates()
    {
        var query = from d in db.States
                    select new
                    {
                        StateID = d.StateID,
                        State = d.State
                    };
        var result = from q in query.ToList()
                     select new SelectedListItem
                     {
                         Value = d.StateID.ToString(),
                         Text = d.State.ToString()
                     }
        return result;
    }
