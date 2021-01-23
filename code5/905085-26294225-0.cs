            try
            {
              OleDbConnection con = new OleDbConnection("
                                                Provider=Microsoft.Jet.OLEDB.4.0;
                                                Data Source=" + Server.MapPath("TestExcel.xlsx") + ";
                                                Extended Properties='Excel 8.0;HDR=Yes;'" 
                                               );
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]",
                                                                                 con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
