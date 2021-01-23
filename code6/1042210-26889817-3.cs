    protected void Page_Load(object sender, EventArgs e)
    {
        GetSQLData();
    }
    
    //my custom function to get data and create relationship between 2 tables and 
    //bind the data on page load so that when menu1 is databound, it will find the matching submenu       
    //items in the database and bind them to the second (nested) repeater, 
    //displaying the sub-menu items below the parent
    
    protected void GetSQLData()
    {
        using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
        {
            conn1.Open();
            SqlDataAdapter cmd = new SqlDataAdapter(@"SELECT * FROM [Abilities]; SELECT * FROM [Heros]", conn1);
            DataSet ds = new DataSet();
            cmd.Fill(ds);
            ds.Relations.Add(new DataRelation("nestThem", ds.Tables[0].Columns["num"], ds.Tables[1].Columns["AbilityID"]));
            repMenu1.DataSource = ds;
            repMenu1.DataBind();
        }
    }
    //Binding the data
    protected void repMenu1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = e.Item.DataItem as DataRowView;
        if (dv != null)
        {
            Repeater repSubMenu = e.Item.FindControl("repMenu2") as Repeater;
            if (repSubMenu != null)
            {
                repSubMenu.DataSource = dv.CreateChildView("nestThem");
                repSubMenu.DataBind();
            }
        }
    }
