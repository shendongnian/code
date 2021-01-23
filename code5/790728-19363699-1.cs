    protected void Button1_Click(object sender, EventArgs e)
    {
        string type = DropDownList1.SelectedItem.ToString();
        string name = TextBox2.Text;
        string nop = DropDownList2.SelectedItem.ToString();
        int num = int.Parse(nop);
        string connectionString = WebConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
    
        string qry3 = "select * from availiability where RoomType=@type";
        SqlCommand cmd3 = new SqlCommand(qry3, connection);
        cmd3.Parameters.AddWithValue("@type", type);
        cmd3.ExecuteReader();
        SqlDataAdapter ad = new SqlDataAdapter(cmd3);
        Dataset ds = new Dataset();
    	ad.Fill(ds);
    	if (ds ! =null)
     {	
        if (ds.Rows.Count > 0)
        {
    
            if ((int)ds.Rows[0]["no_of_rooms"] > num) //Check if rooms are available 
            {
                string qry = "insert into RoomType values('" + type + "','" + name + "','" + num + "') ";
                SqlCommand cmd = new SqlCommand(qry, connection);
                connection.Open();
                int g = cmd.ExecuteNonQuery();
                if (g != 0)
                    Label5.Text = "Reserved for" + name;
                connection.Close();
    
                string qry2 = "update availiability set RoomType=@type ,availiable_rooms=@av";
                SqlCommand cmd2 = new SqlCommand(qry2, connection);
                cmd2.Parameters.AddWithValue("@type", type);
                cmd2.Parameters.AddWithValue("@av", convert.toint32(ds.Rows[0]["no_of_rooms"]) - num);
                connection.Open();
                cmd2.ExecuteNonQuery();
                connection.Close();
    
            }
        }
    	}
        else
        {
            label5.Text = "No Rooms Availiable in " + type;
        }
    }
