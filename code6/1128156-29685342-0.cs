    private void btnOpslaanwerknemergegevens_Click(object sender, EventArgs e)
    {
        string cmdText = @"UPDATE werknemer 
                           SET naam = @nam 
                           voornaam = @voornaam
                           .... continue with other fields 
                           .... and finish with
                           WHERE ID = @id";
        using(SqlConnection con = new SqlConnection(.... connectionstring ....))
        using(SqlCommand cmd = new SqlCommand(cmdText, con))
        {
             con.Open();
             cmd.Parameters.Add("@naam", SqlDbType.NVarChar).Value = txtNaam.Text; 
             cmd.Parameters.Add("@vornaam", SqlDbType.NVarChar).Value = txtVoornaam.Text; 
             ... continue adding a parameter for every field value .....    
             ... and finally call ...
             cmd.ExecuteNonQuery();
       }
