    private void getMenu()
    {
        DataSet ds = objSec.ShowMenu(s_UserId);
        DataTable dt = ds.Tables[0];
        AddMenuItems(dt, 0, menu.Items);
    }
    
    private void AddMenuItems(DataTable dt, int parentId, MenuItemCollection items)
    {
        DataRow[] rows = dt.Select("ParentID=" + parentId.ToString());
        foreach(var dr in rows)
        {
            var id = (int) dr["MenuID"];
            var menuItem = new MenuItem(dr["MenuName"].ToString(), id.ToString(),
                                        "", dr["URL"].ToString());
            items.Add(menuItem);
            // Add subitems
            AddMenuItems(dt, id, menuItem.ChildItems); 
        }
    }
