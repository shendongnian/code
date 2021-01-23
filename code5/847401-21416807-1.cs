    private bool HasTabs(FrameworkElement container)
    {
        RibbonContextualTabGroup tabGroupHeader = container as RibbonContextualTabGroup;
        if (tabGroupHeader == null ||
            !tabGroupHeader.IsVisible)
        {
            return false;
        }
        if (Ribbon.IsMinimized)
            return true;
        foreach (RibbonTab tab in tabGroupHeader.Tabs)
        {
            if (tab != null && tab.IsVisible)
            {
                return true;
            }
        }
        return false;
    }
