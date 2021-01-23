        public DataTable GetExcelinDatatable(string filelocation)
        {            
            DataTable dt = new DataTable();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            OleDbConnection con = new System.Data.OleDb.OleDbConnection(connectionString);
            con.Open();
            OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("select * from [SHEET1$]", con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
