    public int Depth
    {
        get
        {
            if (Items.Count == 0)
            {
                return 0; // Definitely not 1?
            }
            return Items.OfType<MenuGroup>()
                        .Select(x => x.Depth)
                        .DefaultIfEmpty() // 0 if we have no subgroups
                        .Max() + 1;
        }
    }
