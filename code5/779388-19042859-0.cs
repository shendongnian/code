    public static DataSet ExecuteDataset(string strcommandText,CommandType commandType,SqlParameter[] p=null)
     {
       CreateConnection();
       da = new SqlDataAdapter(strcommandText, con);
       da.SelectCommand.CommandType = commandType;
       if(p!=null)
       {
         da.SelectCommand.Parameters.AddRange(p);
       }
       ds = new DataSet();
       da.Fill(ds);
       return ds;
     } 
  
    public static DataSet GetDeptDetails()
        {
        string strcommandText = "sp_DeptDetails";
        return SqlHelper.ExecuteDataset(strcommandText,CommandType.StoredProcedure);
         } 
