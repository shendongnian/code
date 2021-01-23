    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = 
      @"Data Source=ALIPC;initial catalog=TrainingDatabase;integrated security=True";       
    SqlCommand cmd = new SqlCommand();
    cmd.CommandText = "select * from question";
    cmd.Connection = conn;
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);            
    return dt;
    //   you can call this method wherever
    classname c=new classname();
    foreach(datarow dr in c.methodname().rows)
    {
        user u=new user();
        u.userid = dr["userid"];
        list.add(u);
    }
    return list;
