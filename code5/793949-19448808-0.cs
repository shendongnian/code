        List<MenuItem> GetMenuItemsByParentId(int parentId)
        {
        EntityContext newContext = new EntityContext();
        List<MenuItem> getMenuItems = newContext.MenuItems.Where(c => c.ParentId == parentId).ToList();
        newContext.Dispose();
        return getMenuItems;
        }
