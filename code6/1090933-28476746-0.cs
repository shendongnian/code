    private void searchbtn_Click(object sender, EventArgs e)
    {
            SqlConnection sql = new SqlConnection("Your String Connection");
            SqlDataAdapter adapter = new SqlDataAdapter(@"Select Name, FileName From Table Where Name Like @Name", sql); 
            adapter.SelectCommand.Parameters.AddWithValue("@Name", string.Format("%{0}%", textBox1.Text));
    }
