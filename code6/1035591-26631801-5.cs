        protected void btnAdd_Click(object sender, EventArgs e)
      {
       using (SqlConnection con = new SqlConnection())
       {
        string query;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString);
        conn.Open();
        query = "Insert into Categories_For_Merchant values (ddl_category.selectedItem.value,'" + txtCategoryAdding.Text + "', '" + txtDescription.Text + "')";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script>alert('Category added succesfully');</script>");
        txtCategoryAdding.Text = "";
        txtDescription.Text = "";
    }
}
