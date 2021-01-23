    string strFileName = textpath + "\\filename.csv";
    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) +"; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
    conn.Open();
    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
    DataSet ds = new DataSet("Temp");
    adapter.Fill(ds);
    DataTable tb = ds.Tables[0];
