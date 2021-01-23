    if(radioButton_comunitaria.Checked)
    {
        dataCommand.Parameters.Add("@Comunitaria", OleDbType.VarChar).Value = true;
    }
    else
    {
        dataCommand.Parameters.Add("@Comunitaria", OleDbType.VarChar).Value = false;
    }
    dataCommand.Parameters.Add("@Observacion", OleDbType.VarChar).Value = obs;
    dataCommand.ExecuteNonQuery();
