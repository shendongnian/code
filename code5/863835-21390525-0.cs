    protected void btnValiderModifier_Click(object sender, EventArgs e)
    {
    	using(SqlConnection conn = new SqlConnection(connString))
    	{
    		string myid = getIds();
    		try
    		{
    			conn.Open();
    			SqlCommand cmd = new SqlCommand("update Enfants set prenom =@prenom,  DateNaissance=@dateNaissance, Scolarise=@scolarise, Activite=@activite where codeEnfants=@codeEnfants", conn);
    			cmd.Parameters.AddWithValue("@prenom", TextBox_NPmodif.Text);
    			cmd.Parameters.AddWithValue("@DateNaissance", TextBox_DNmodif.Text);
    			cmd.Parameters.AddWithValue("@Scolarise", TextBox_Scolarisemodif.Text);
    			cmd.Parameters.AddWithValue("@Activite", TextBox_Activitemodif.Text);
    			cmd.Parameters.AddWithValue("@codeEnfants", myid);
    			cmd.ExecuteNonQuery();
    			Response.Write("<script>alert('Opération reussie')</script>");
    
    		}
    		catch(SqlException sqlEx)
    		{
    			//what is the point of cacthing if you do use the exception?
    			Response.Write("error" + sqlEx.Message);
    			Response.Write("<script>alert ('Erreur lors de la modif!')</script>");
    		}
    	}
    }
