    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(LoadDB));
    thread.Start();
    //put this command wherever you want
    private void LoadDB()
    {
    SqlConnection CONN=new SqlConnection(SomeConnectionString);
    CONN.Open();
    
    SqlCommand cmd = CONN.CreateCommand();
    cmd.CommandText="SELECT FIELD1,FIELD2,FIELD3 from table1";
    
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    
    DataTable dt = new DataTable();
    da.Fill(dt);
    }
