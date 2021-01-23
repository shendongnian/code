    string _User_modify= (string)cmd.ExecuteScalar();
    DateTime dt;
    if(DateTime.TryParseExact(_User_modify, 
                           "dd/MM/YYYY", 
                           CultureInfo.InvariantCulture, 
                           DateTimeStyles.None, 
                           out dt))
    {
        tpPasswordExpiry.Value =dt;
    }
