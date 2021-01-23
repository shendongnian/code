    id = Request.QueryString["diamond_id"]; //Probably should use String.IsNullOrEmpty and display a message to the client if the parameter isn't here
    var cmd = new SqlCommand("SELECT * FROM diamond_detail WHERE final_diamond_id=@id");
    cmd.Paramaters.AddWithValue("id", id);
    var dt = new DataTable();
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["JemfindConnectionString"].ConnectionString));
    {
        cmd.Connection = conn;
        conn.Open();  
        dt.Load(cmd.ExecuteReader()); //We eliminated the SqlDataAdapter
    }
    var record = dt.AsEnumerable().Single(); //retrieve one DataRow from DataTable
    diamond_carat_lbl.Text = record.Field<string>("carats"); //Get the field called carats
    diamond_name_lbl.Text = record.Field<string>("name");
