    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var itemIDs = string.Join(",", ((IList<string>)Session["Items"]).ToArray());
            var sqlQuery = String.Format("SELECT * FROM tableName WHERE itemID IN ({0})", itemsIDs);
    
            SqlDataSource1.SelectCommand = sqlQuery;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
    }
