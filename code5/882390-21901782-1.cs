    List<SqlParameter> params_list = new List<SqlParameter>();
    if(ProfileID==null)
    {
       SqlParameter param_ProfileID = new SqlParameter("@PROFILE_ID", DBNull.Value);
    }
    else
    {
       SqlParameter param_ProfileID = new SqlParameter("@PROFILE_ID", ProfileID);
    }
    param_StoreID.SourceColumn = "PROFILE_ID";
    param_StoreID.DbType = DbType.Int64;
    params_list.Add(param_ProfileID); 
