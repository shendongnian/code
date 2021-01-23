    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string subcat = Request.QueryString["subcat"];
            string bnd = Request.QueryString["bnd"];
    
            string query = "SELECT * FROM [ProductDetails] WHERE ([Sub_category] = " + subcat + ")";
            if (!String.IsNullOrEmpty(bnd))
            {
                query += " AND ([Brand] = " + bnd + ")";
            }                
                
            SqlDataSource1.SelectCommand = query;                
        }
    }
