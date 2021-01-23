    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\yourExcel.xls;Extended Properties='Excel 8.0;HDR=Yes'"))
    {
        conn.Open();
        OleDbCommand cmd = new OleDbCommand("CREATE TABLE [Sheet1] ([Column1] string,
                     [Column2] string, [Column3] string, [Column4] string)",
                     conn);
        cmd.ExecuteNonQuery();
        cmd = new OleDbCommand("Insert Into [Sheet1] Values ('a','b','c','d')", conn);
        cmd.ExecuteNonQuery();
    }
