    protected void lstAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectSQL;
        selectSQL = "SELECT * FROM tblnewgroup ";
        selectSQL += "WHERE Groupno=" + lstAuthor.SelectedValue;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
    try
    {
        con.Open();
        reader = cmd.ExecuteReader();
        if(reader.Read())
        {
        txtGn.Text = reader["Groupno"].ToString();
        txtgname.Text=reader["Groupname"].ToString();
        txtsl.Text=reader["Slno"].ToString();
        txtsn.Text = reader["Subname"].ToString();
        lblResults.Text = "Data Updated Successfully!";
        }
        else
        {
          lblResults.Text = "No Records found!";
        }
        reader.Close();
        
    }
    catch (Exception err)
    {
        lblResults.Text = "Error getting author. ";
        lblResults.Text += err.Message;
    }
    finally
    {
        con.Close();
    }
    }
