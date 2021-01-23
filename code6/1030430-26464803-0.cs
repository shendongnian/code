    public IEnumerable<Ban> FindBans(Ban filter)
    {
        var bans = GetBansQueryable();
    
        if (!string.IsNullOrWhiteSpace(filter.GroupName))
        {
            bans = bans.Where(b => b.GroupName == filter.GroupName);
        }
        if (!string.IsNullOrWhiteSpace(filter.Nick) && !string.IsNullOrWhiteSpace(filter.IP))
        {
            bans = bans.Where(b => b.Nick == filter.Nick || b.IP == filter.IP);
        }
        else if (!string.IsNullOrWhiteSpace(filter.Nick))
        {
            // filter.IP is empty
            bans = bans.Where(b => b.Nick == filter.Nick);
        }
        else if (!string.IsNullOrWhiteSpace(filter.IP))
        {
            // filter.Nick is empty
            bans = bans.Where(b => b.IP == filter.IP);
        }
    
        return bans.AsEnumerable();
    }
