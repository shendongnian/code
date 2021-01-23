    public int Depth
    {
        get
        {
            // Completely empty menu (not even any straight items). 0 depth.
            if (Items.Count == 0)
            {
                return 0;
            }
            // We've either got items (which would give us a depth of 1) or
            // items and groups, so find the maximum depth of any subgroups,
            // and add 1.
            return Items.OfType<MenuGroup>()
                        .Select(x => x.Depth)
                        .DefaultIfEmpty() // 0 if we have no subgroups
                        .Max() + 1;
        }
    }
