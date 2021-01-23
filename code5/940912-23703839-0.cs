    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn() 
     { DataType = Type.GetType("System.String"), ColumnName = "colname" });
    DataRow row;
    stringArray.ToList().ForEach(s => 
     { 
       row = dt.NewRow();
       row["colname"] = s;
       dt.Rows.Add(row); 
     });
    cmd.Parameters.Add(new SqlParameter("@colname", SqlDbType.Structured)
     {
       Direction = ParameterDirection.Input,
       Value = dt,
     });
