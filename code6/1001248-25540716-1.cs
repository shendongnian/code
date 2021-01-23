    protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String strQuery = "select SubCategoryID,SubCategoryName from SubCategoryMast where CategoryID="+ddlCategory1.SelectedValue;
        using (SqlConnection con = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                con.Open();
                ddlSubCategory1.Items.Clear();
                ddlSubCategory1.DataSource = cmd.ExecuteReader();
                ddlSubCategory1.DataTextField = "SubCategoryName";
                ddlSubCategory1.DataValueField = "SubCategoryID";
                ddlSubCategory1.DataBind();
                ddlSubCategory1.Items.Insert(0, new ListItem("Select SubCategory", "-1"));
                con.Close();
            }
        }
    }
