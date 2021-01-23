           string file = @"C:\Projects\EverydayProject\test.xlsx";
           string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        file + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string query = @"select * from [Table$]";
            DataTable tb = new DataTable();
            using(OleDbDataAdapter ad = new OleDbDataAdapter(query, conn))
            {
                ad.Fill(tb);
            }
            
            conn.Close();
