    string query = "DELETE FROM Child WHERE ChildID = @id";
    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, myConnection);
    cmd.Parameters.AddWithValue("@id", int.Parse(DropDownList1.SelectedValue));
    try
    {
        myConnection.Open();
        cmd.ExecuteNonQuery();
    }
    finally
    {
        if (myConnection.State != System.Data.ConnectionState.Closed) myConnection.Close();
    }
