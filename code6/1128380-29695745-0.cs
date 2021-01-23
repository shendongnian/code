     try
    {
        SqlConnection con = new SqlConnection("Data Source=STUDENT-PC;Initial Catalog=BuyBid;Integrated Security=True;Asynchronous Processing=False;");
        //creates a new sqlcommand to update the buyer's information to the Database.
        SqlCommand cmd = new SqlCommand("UPDATE BUYER SET Name = '" + txtNameUpdate.Text + "' ,Surname = '" + txtSurnameUpdate.Text + "', Email = '" + txtemailUpdate.Text + "', CellNumber = '" + txtCellUpdate.Text + "'", con);
        con.Open();
        int rows = cmd.ExecuteNonQuery();
        con.Close();
    }
    catch (Exception Ex)
    {
        MessageBox.Show(Ex.Message + Environment.NewLine + Ex.TargetSite, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     }
