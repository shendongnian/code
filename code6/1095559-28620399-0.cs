    var ds = new DataSet();
    using (var cnn = new SqlConnection(CONNECTION_STRING))
    {
        string cmdText = "SELECT * FROM User_TBL_DB WHERE Lastname LIKE '%@Search%'";
        var cmd = new SqlCommand(cmdText, cnn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Search", SearchBOX.Text);
    
        cnn.Open();
    
        var da = new SqlDataAdapter();
        da.SelectCommand = cmd;
                    
        da.Fill(ds, "Name");
    }
    
    GridView2.DataSource = ds;
    GridView2.DataBind();
