    private void LoadData()
    {
    static string Constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/PathToYourAccessFile";
    string SQLstr = "Select * from YourAccessTable";
    OleDbConnection Conn = new OleDbConnection(Constr);
    Conn.Open();
    OleDbDataAdapter ODA;
    DataTable DT;
    ODA = new OleDbDataAdapter (SQLstr, Conn ); 
    DT = new DataTable();
    ODA.Fill(DT);
    dataGridView1.DataSource = DT ;
    Conn.Close();
    }
