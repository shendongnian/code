    public void ddl_Cat()
    {
        if (!Page.IsPostBack)
        {
            MySqlCommand sql_Category = new MySqlCommand("SELECT DISTINCT(Category) FROM DVD", cs);
            cs.Open();
            MySqlDataReader ddlgetcat;
            ddlgetcat = sql_Category.ExecuteReader();
            ListViewCat.DataSource = ddlgetcat;
            ListViewCat.DataBind();
            cs.Close();
            cs.Dispose();
        }
    }
