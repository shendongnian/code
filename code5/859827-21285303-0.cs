    string sql = "select * from sys.columns where Name = @columnName and Object_ID = Object_ID(@tableName)";
    DataSet ds= new DataSet();
    EntityConnection entityConn = (EntityConnection)ctx.Connection;
    SqlConnection sqlConn = (SqlConnection)entityConn.StoreConnection;
    SqlCommand cmd = new SqlCommand(sql, sqlConn);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    using (cmd)
    {
           SqlParameter Prm = new SqlParameter("tableName", "OrderDetails");
           cmd.CommandType = CommandType.Text;
           cmd.Parameters.Add(Prm);
           da.Fill(ds);
     }
