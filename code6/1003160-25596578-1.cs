    string query="select ts.Name,ts.FamilyName,ts.Id_student,td.Name,tn.NomreAdad from     tblStudent ts,tblDars     td,tblNomre tn where tn.NomreAdad>=@from AND tn.NomreAdad<=@to AND ts.Id=tn.Id_student AND td.Id=tn.Id_dars";
    
    //Create Sqlconnection object
    using(SqlConnection con = new SqlConnection(connectionstring))
    {
    //open the connection
    con.Open();
    SqlDataAdapter sda = new SqlDataAdapter(query, con);
    //To avoid sql injection using parameters
    sda.Paramaters.AddWithValue("@from",from);
    sda.Paramaters.AddWithValue("@to",to);
    DataTable dt = new DataTable();
    sda.Fill(dt);
    GridView1.DataSource = dt;
    GridView1.DataBind();
    }
