    using (var connection = factory.Open())
    {
        var download = 
             connection.Exec(c =>
              {
                   c.CommandText = "PRODUCT_DETAILS";
                   c.CommandType = CommandType.StoredProcedure;
                   c.Parameters.Add(
                      new Oracle.DataAccess.Client.OracleParameter("p_code", Oracle.DataAccess.Client.OracleDbType.NVarchar2) { Value = redemptionCode });
                   c.Parameters.Add(
                       new Oracle.DataAccess.Client.OracleParameter("cursorParam", Oracle.DataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output });
                    return c.ExecuteReader().ConvertToList<ProductDownloads>();
               });
    
               foreach (var productDownload in download)
               {
                   Console.WriteLine(productDownload.Name);
               }
    }
