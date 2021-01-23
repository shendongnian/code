    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ParentId = null;
    
        if (ddlCategory.SelectedIndex != 0)
        {
            ParentId = ddlCategory.SelectedValue;
        }
        string query = "Insert into tbl_Category(CatName,Parent_Id) values (@CatName,@Parent_Id)";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@CatName", SqlDbType.NVarChar).Value = txtAddCategories.Text;
                object pID = DBNull.Value;
                if(ParentID != null) pID = int.Parse(ParentId);
                command.Parameters.Add("@Parent_Id", SqlDbType.Int).Value = pID;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
