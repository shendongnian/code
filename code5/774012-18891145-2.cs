    private void btnInsert_Click(object sender, EventArgs e)
       {
        if (txtName.Text == string.Empty)
        {
            MessageBox.Show("Please enter a value to Project Name!");
            txtName.Focus();
            return;
        }
        if (txtContactPerson.Text == string.Empty)
        {
            MessageBox.Show("Please enter a value to Description!");
            txtContactPerson.Focus();
            return;
        }
        SqlConnection con = Helper.getconnection();
        con.Open();
        string commandText = "InsertClient";
        SqlCommand cmd = new SqlCommand(commandText, con);
        cmd.Parameters.AddWithValue("@Name", txtName.Text);
        cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
        cmd.CommandType = CommandType.StoredProcedure;
	try
	{
        object Name = cmd.ExecuteNonQuery();
        MessageBox.Show("Client details are inserted successfully");
        txtName.Clear();
        txtContactPerson.Clear();
        BindData();
	}
	catch(Exception ex)
	{
            //Handle exception, Inform User
	}
	finally
	{
            con.Close();
	}      
    }
