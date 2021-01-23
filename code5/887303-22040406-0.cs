    string Sql = "select status from lk_tb_project_status";
    OleDbConnection con = new OleDbConnection(constr);
    OleDbCommand com = new OleDbCommand(Sql, con);
    
    con.Open();
    
    comboBox1.Items.Insert(0,"Select Status");
    OleDbDataReader DR = com.ExecuteReader();
    while (DR.Read())
    {
       comboBox1.Items.Add(DR[0]); 
    }
