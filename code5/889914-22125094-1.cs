    public IEnumerable<MenuItemDTO> GetAllMenuItems()
    {
      using (Entities db = new Entities())
      {
        //get all items and put them in a simple list
        var allItems = (from m in db.MenuItems
                    select new MenuItemDTO
                    {
                        MenuItemID = m.MenuItemID,
                        Title = m.Title,
                        ParentID = m.ParentID
                    }).ToList();
        //define another list and put "only" root items in it
        //  this will have a hierarchical structure (By correcting the Children)
        //  and it's the output of this function
        var roots = allItems.Where(x => x.ParentID == null);
        //here we correct Children of each item
        //since both allItems and roots share the same elements (call-by-reference)
        //instead of searching through a tree, simply search through allItems
        foreach (var item in allItems)
        {
          //find the correct parent for current item
          var parent = allItems.FirstOrDefault(x => x.MenuItemID == item.ParentID);
          //add the item to Children of its parent
          //   by doing this, one single item in both allItems 
          //   and roots (or recursively in roots) will be corrected
          if(parent!=null)
               parent.Children.Add(item);
          //if you don't want to miss any menu item:
          //else roots.Add(item);
        }
        return roots;
      }
    }
