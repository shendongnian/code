       ## Dynamic Update Query from Datatable with Npgsql##
      public string UpdateExecute(DataTable dataTable, string TableName)
    {
        NpgsqlCommand cmd = null;
        string Result = String.Empty;
        try
        {            
            if (dataTable.Columns.Contains("skinData")) dataTable.Columns.Remove("skinData");
            string columns = string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            string values = string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(c => string.Format("@{0}", c.ColumnName)));
            StringBuilder sqlCommandInsert = new StringBuilder();
            sqlCommandInsert.Append("Update " + TableName + " Set ");
            string[] TabCol = columns.Split(',');
            string[] TabVal = values.Split(',');
            for (int i = 0; i < TabCol.Length; i++)
            {
                for (int j = 0; j < TabVal.Length; j++)
                {
                    sqlCommandInsert.Append(TabCol[i] +" = "+ TabVal[i] + ",");
                    break;
                }
            }
          string  NpgsqlCommandUpdate= sqlCommandInsert.ToString().TrimEnd(',');
          NpgsqlCommandUpdate += (" where " + TabCol[0] + "=" + TabVal[0]);
            
            using (var con = new NpgsqlConnection("Server=localhost;Port=5432;uid=uapp;pwd=Password;database=Test;"))
            {
                con.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    cmd = new NpgsqlCommand(NpgsqlCommandUpdate.ToString(), con);
                    cmd.Parameters.Clear();
                    foreach (DataColumn col in dataTable.Columns)
                        cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col]);
                    Result = cmd.ExecuteNonQuery().ToString();
                }
            }
        }
        catch (Exception)
        {
            Result = "-1";
        }
        return Result;
    }   
