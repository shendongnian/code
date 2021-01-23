        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Lot", SqlDbType.VarChar, 112);
        param[0].Value = "Bob123457";
    
        DataSet ds1 = db.ExecuteDataSet("Getmagesbylot2", param );
    
    OR
    
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Lot", SqlDbType.NVarChar, 112);
        param[0].Value = "Bob123457";
    
        DataSet ds1 = db.ExecuteDataSet("Getmagesbylot2", param );
