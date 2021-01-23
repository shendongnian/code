    var connection = new SqlConnection(connectionString);
    var cmd = new SqlCommand(insertSql, connection);
    cmd.Parameters.AddWithValue("@UsrNme", txtUID.Text.ToString());
    cmd.Parameters.AddWithValue("@fnbox", txtfn.Text.ToString());
    cmd.Parameters.AddWithValue("@lnamebox", txtLN.Text.ToString());
    cmd.Parameters.AddWithValue("@passtxtbx1", txtPassword.Text.ToString());
    cmd.Parameters.AddWithValue("@passtxtbx1", txtPassword.Text.ToString());
    cmd.Parameters.AddWithValue("@passtxtbx2", txtRePass.Text.ToString());
    cmd.Parameters.AddWithValue("@emailbox", txtEmail.Text.ToString());
    cmd.Parameters.AddWithValue("@DrDncoundrlst", txtCountry.Text.ToString());
    cmd.Parameters.AddWithValue("@DropDownListSwestate", txtState.Text.ToString());
    cmd.Parameters.AddWithValue("@citytxtbox", txtCity.Text.ToString());
        
    try
    {
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        
        lblmsg.Text = "You already completed your registration process";
    }
    catch (SqlException ex)
    {
        var errorMessage = "error in registration user";
        
        errorMessage += ex.Message;
        
        throw new Exception(errorMessage);
    }
    finally
    {
        con.Close();
    }
