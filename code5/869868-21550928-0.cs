    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values["Id"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Delete FROM TableName where Id='" + id + "'";
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        GetGridData();
        Response.Write("<script>alert('Module Deleted..!!!');</script>");
    }
