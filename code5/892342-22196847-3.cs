    DataTable dt = new DataTable();
    dt = bll.master_Menu_Bar(en);
    DataRow[] drow = dt.Select();
    foreach (DataRow dr in drow)
    {
        MenuHelper helperItem = new MenuHelper();
        helperItem.PageId = dr["PageId"].ToString();
        helperItem.PageHeader = dr["PageHeader"].ToString();
        helperItem.PageUrl = dr["PageUrl"].ToString();
        //can add menu here or not
        MenuBar.Items.Add(new MenuItem(dr["PageHeader"].ToString(), dr["PageId"].ToString(), "", dr["PageUrl"].ToString()));
        //Add items to list
        menulist.Add(helperItem);
    }
     
    //Add list to session or view state
    Session["MenuItems"] = menulist;
    //When retrieving list do like this
    List<MenuHelper> menulist = (List<MenuHelper>)Session["MenuItems"];
