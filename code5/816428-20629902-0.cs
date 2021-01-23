    try
    {
        using (TransactionScope scope01 = new TransactionScope(opt, span))
        {
            using (var sqlcon = new SqlConnection(sSqlCon))
            {
                //select,insert , update statements
            }
    
            scope01.Complete();
        }
    }
