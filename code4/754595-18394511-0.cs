        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con; //Your connection string"
        cmd.CommandText = "Select * from table1"; // your query
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        int count=0;
        for (int i = 0; i > dt.Rows.Count; i++)
        {
            if (Convert.ToString(dt.Rows[i]["LastName"]) == Lastname)
            {
                count++;
            }
        }
        if (count > 0)
        {
            //insert code for data
        }
        else
        {
            var script = "alert('"+ Lastname + "already exist.');";
            ClientScript.RegisterStartupScript(typeof(Page), "Alert", script, true);
            // or you can use here your Update statement
        }
