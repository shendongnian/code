    public Form1()
    {
        InitializeComponent();
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Drew\Documents\Visual Studio 2012\Projects\Football\Football\db\FB_DB.mdb;User Id=admin;Password=;");
        //Load QB DropDown
        conn.Open();
        OleDbCommand cmd = new OleDbCommand("select PlayerID,LastName,FirstName from tb_players where Pos = 'QB' Order By LastName", conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        string plyrName = "";
        int keyValue;
        cbQb.DisplayMember = "Value";
        cbQb.ValueMember = "Key";
        
        while (reader.Read())
        {
            plyrName = reader["LastName"].ToString() + ", " + reader["FirstName"].ToString();
            index = Convert.ToInt32(reader["primaryKeyColumnValue"]);
            KeyValuePair<int, string> cmbItem = new KeyValuePair<int, string> (index ,plyrName)
            cbQb.Items.Add(cmbItem);
        }
        conn.Close();
    }
