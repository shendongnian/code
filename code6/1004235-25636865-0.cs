    public IQueryable<Bus> Search(string[] states)
    {
        // Give all the buses that are inside the list of states that i giving you, no matter upper case or lower case
        IQueryable<Bus> query = this.context.Buses;
        if (states.Length > 0)
        {
            states = states.Select(s => s.ToLower()).ToArray();
            query = query.Where(b => states.Contains(b.State.ToLower()));
        }
    return query;
    }
