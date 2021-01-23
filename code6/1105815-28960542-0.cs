    com.CommandText = "update tblStore set Amount=Amount + @amount, LatestUpdate=@latestUpdate, Notes = convert(nvarchar(4000),@notes) + '. " + item.notes + "' WHERE ID=1";
    com.Parameters.Add("@amount", System.Data.SqlDbType.Decimal);
    SqlParameter parameter = new SqlParameter("@amount",  System.Data.SqlDbType.Decimal);
    parameter.Value = item.amount;
    com.Parameters.Add(parameter);
    
    parameter = new SqlParameter("@latestUpdate", System.Data.SqlDbType.DateTime);
    parameter.Value = item.fuelingDate;
    com.Parameters.Add(parameter);
    
    parameter = new SqlParameter("@notes", System.Data.SqlDbType.NVarChar);
    parameter.Value = item.notes;
    com.Parameters.Add(parameter);
