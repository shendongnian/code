    public static DataTable GetBatches(long storeID, long? ProfileID)
    {
        List<SqlParameter> pList = new List<SqlParameter>();
        string query = string.Empty;
        if(ProfileID.HasValue)
        {
            query = "SELECT .... where PROFILE_ID= @proID AND STORE_ID= @stoID";
            SqlParameter pProfileID = new SqlParameter("@proID", SqlDbType.BigInt)
                                          .Value = ProfileID.Value;
            SqlParameter pStoreID = new SqlParameter("@stoID", SqlDbType.BigInt)
                                          .Value = storeID;
            pList.Add(pProfileID);
            pList.Add(pStoreID);
        }
        else
        {
            query = "SELECT .... where STORE_ID= @stoID";
            SqlParameter pStoreID = new SqlParameter("@stoID", SqlDbType.BigInt).Value = storeID;
            pList.Add(pStoreID);
        }
         
        
