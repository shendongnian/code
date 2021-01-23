     private void GetMenu()
    {
    //fetches data from business logic layer
        DataTable dt1 = new DataTable();
        dt1 = bll.Master_Menu_Bar(en);
    //session so that the masterpage doesnt interact with database on everypostback
        Session["dataTable"] = dt1;
        DataTable dt=new DataTable();
        dt=(DataTable)Session["dataTable"];
    //session for page id's of the menuitems which will be checked for authorization at page loads of every page.
        int i = 0;
        while (i < dt.Rows.Count)
        {
            int[] PageId = new int[dt.Rows.Count];
            PageId[i] = Convert.ToInt32(dt.Rows[i][2]);
            Session["PageId" + i] = PageId[i];
            i++;
        }
    //A session to keep count of the no. of menu items , this session is also used at page loads of pages as condition of if statement
        Session["count"] = dt.Rows.Count;
        DataRow[] drow = dt.Select();
        foreach (DataRow dr in drow)
        {
            MenuBar.Items.Add(new MenuItem(dr["PageHeader"].ToString(), dr["PageId"].ToString(), "", dr["PageUrl"].ToString()));
        }
