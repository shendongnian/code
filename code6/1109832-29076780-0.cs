    public string GuestIDs
    {
        get
        {
            return string.Join(",", Guests.Select(g => g.GuestId));
        }
    }
