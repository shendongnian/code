    using(OleDbConnection conDataBase = new OleDbConnection(constring))
    using(OleDbCommand cmdDatabase = conDataBase.CreateCommand())
    {
        ...
        ...
        using(OleDbDataReader myReader = comm.ExecuteReader())
        {  
           //
        }
    }
