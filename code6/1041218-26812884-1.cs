    using (var command = db.GetStoredProcCommand("AS_AuthenticateByPartner"))
    {
        db.CommandType = CommandType.StoredProcedure;
        db.AddInParameter(command, "partnerID", DbType.String, partnerId);
        // make sure myConnection is open before querying the database
        var reader = db.ExecuteReader();
        if (!reader.HasRows)
            return null;  // no records found... return null? display error?
        reader.Read();
        return new Login {username = reader.GetString(0), password = reader.GetString(1)};
    }
