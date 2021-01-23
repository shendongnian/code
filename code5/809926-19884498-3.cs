    private void LoadData() 
    {
        DataTable dt = new DataTable();
        MySqlConnection connStr = new MySqlConnection();
        connStr.ConnectionString = "Server = localhost; Database = healthlivin; Uid = root; Pwd = khei92;";
        String searchPerson = "SELECT PersonIDB from contactFriend WHERE PersonID = @id";
        MySqlCommand cmdSearch = new MySqlCommand(searchPerson, connStr);
        connStr.Open();
        cmdSearch.Parameters.AddWithValue("@id", "M000001");
    
        MySqlDataReader dtrRead2 = cmdSearch.ExecuteReader();
        dt.Load(dtrRead2);
    
        dtrRead2.Close();
        connStr.Close();
    
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
