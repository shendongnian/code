    public int Depth
    {
        get
        {
            if (Items.Count == 0)
                return 0;
            var subMenu = Items.Select(b => b as MenuGroup);
            if (!subMenu.Any())
                return 1;
            var subLevel = subMenu.Cast<MenuGroup>().Select(x = > x.Depth);
            return !subLevel.Any() ? 1 : subLevel.Max() + 1;
        }
    }
