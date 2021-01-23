    using (var myConnection = new OleDbConnection(myConnectionString))
    using (var myCommand = myConnection.CreateCommand())
    {
        var idParam = new OleDbParameter("@id", Izbor.SelectedValue);
    
        myCommand.CommandText = "DELETE FROM Ure WHERE (ID) = @id";
        myCommand.Parameters.Add(idParam);
    
        myConnection.Open();
        myCommand.ExecuteNonQuery();
    }
