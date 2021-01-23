    public static DataTable GetBatches(long storeID, long? ProfileID)
    {
        List<SqlParameter> pList = new List<SqlParameter>();
        string query = "SELECT .... where ";
        if(ProfileID.HasValue)
        {
            query += "PROFILE_ID= @proID";
            SqlParameter pProfileID = new SqlParameter("@proID", SqlDbType.BigInt)
                                          .Value = ProfileID.Value;
            pList.Add(pProfileID);
        }
        else
        {
            query += "STORE_ID= @stoID";
            SqlParameter pStoreID = new SqlParameter("@stoID", SqlDbType.BigInt)
                                          .Value = storeID;
            pList.Add(pStoreID);
        }
         
