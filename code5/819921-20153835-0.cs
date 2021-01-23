    protected void submit_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox submitChk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)submitChk.NamingContainer;
        String npi = (String)GridView1.DataKeys[row.DataItemIndex].Value;
        
        SqlConnection conn = new SqlConnection("your connection string here");
        string updateQuery = "UPDATE DRPprovders SET submit = @submit WHERE npi = @npi";
        SqlCommand cmd = new SqlCommand(updateQuery, conn);
        // If it's checked, pass 1, else pass 0
        cmd.Parameters.AddWithValue("@submit", submitChk.Checked ? 1 : 0);
        cmd.Parameters.AddWithValue("@npi", npi);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
