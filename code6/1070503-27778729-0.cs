        List<ExcelData> exData = new List<ExcelData>();
        .....
        using (OleDbConnection excel_con = new OleDbConnection(conString))
        using (OleDbCommand cmd = new OleDBCommand())
        {
            excel_con.Open();
            string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
            cmd.CommandText = "SELECT * FROM [" + sheet1 + "]";
            cmd.Connection = excel_con;
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                 ExcelData curLine = new ExcelData();
                 curLine.RnEID = Convert.ToDecimal(reader[0]);
                 curLine.EActual = reader[1].ToString();
                 curLine.EAmount = Convert.ToDecimal(reader[2]);
                 exData.Add(curLine);
            }
        }
        return exData;
