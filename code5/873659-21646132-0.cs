    if(fnamereader.Read())
    {
       Fname = fnamereader.GetString(fnamereader.GetOrdinal("FirstName"));
       Sname = fnamereader.GetString(fnamereader.GetOrdinal("SecondName"));
       EmailID = fnamereader.GetString(fnamereader.GetOrdinal("EmailID"));
    }
