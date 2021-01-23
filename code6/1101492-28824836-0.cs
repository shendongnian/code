        DataTable Result = TransactionDataTable.Clone();
        for(int i = 5; i < PageSize && i < TransactionDataTable.Rows.Count ; i++)
        {
            DataRow dr = (DataRow)TransactionDataTable.Rows[i];
    
            Result.ImportRow(dr);
        }
    
        string MobileNumber = TransactionDataTable.Rows[0]["MobileRegistration_MobileNumber"].ToString();
        string MobileNumber2 = Result.Rows[0]["MobileRegistration_MobileNumber"].ToString();
