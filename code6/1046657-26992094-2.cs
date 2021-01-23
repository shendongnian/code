    ParentId is Int value but Your passing at String so you got error convert to int and then you try
    
    
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * from CategoriesForMerchant where ParentId =" + Convert.ToInt32(ddlcategories.SelectedValue) + "", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        
        if (dr.HasRows())
        {
        ddlSubCategories.DataSource = dr;
        ddlSubCategories.Items.Clear();
        ddlSubCategories.DataTextField = "CategoryName";
        ddlSubCategories.DataValueField = "CategoryName";
        ddlSubCategories.DataBind();
        ddlSubCategories.Items.Insert(0, new ListItem("--Select Sub Category--", "NA"));
        conn.Close();
        dr.Close();
        }
    }
