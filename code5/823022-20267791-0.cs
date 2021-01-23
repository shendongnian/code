    public class DAL
    {
        OleDbDataAdapter DbAdap;
        DataTable dt;
        public DataTable Get_ExcelSheet()
        {
            OleDbConnection DbCon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Nimit\\ExcelApplication.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"");
            DbAdap = new OleDbDataAdapter("SELECT * FROM [Sheet1$]",DbCon);
            dt = new DataTable();
            DbAdap.Fill(dt);
            return dt;
        }
    }
