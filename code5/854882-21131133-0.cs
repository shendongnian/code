    // Fetch Both Project Name and Project Id    
    string Sql = "select project_name, project_id from tb_project";
    con = new OleDbConnection(constr);
    com = new OleDbCommand(Sql, con);
    con.Open();  
    OleDbDataReader DR = com.ExecuteReader();
    DataTable dt;  
    dt.Load(Dr);
    combo_status.DataSource = dt; //Check it this works or not
    
    combo_status.DisplayMember = "ProjectName";
    combo_status.ValueMember= "ProjectId";
