    private void btnSubmit_Click(object sender, EventArgs e)
    { 
        string name = txtName.Text;
        String sql = "insert into UserName values (@Username)";
        SqlCommand com = new SqlCommand(sql, ConnectionManager.Connection());
        com.Parameters.AddWithValue("@Username", name);
        com.ExecuteNonQuery();
        lblMessage.Text = "Record added successfully";
        txtName.Text = "";
    }
