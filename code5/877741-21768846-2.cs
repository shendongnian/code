       using (SqlCommand sqlcmd = new SqlCommand("", sqlconn))
       {
           sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
           sqlcmd.CommandText = mySql.GetLCR(); 
           SqlParameter p1 = new SqlParameter("@GatewayID", SqlDbType.NVarChar, 20).Value = GatewayID; 
           SqlParameter p2 = new SqlParameter("@DialNumber", SqlDbType.NVarChar, 20).Value = dialnumber; 
           sqlCmd.Parameters.AddRange(new SqlParameter[] {p1, p2});
           sqlcmd.CommandTimeout = 1;
           sqlconn.Open();
           .....
