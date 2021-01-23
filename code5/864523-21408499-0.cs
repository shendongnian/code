    using (SqlDataReader reader1 = cmd.ExecuteReader())
    {
        while (reader1.Read())
        {
            int numUserID = reader1.GetInt32(1);
            string strFirstName = reader1.GetString(3);
            string strLastName = reader1.GetString(4);
            string newUserName = strFirstName + " " + strLastName;
    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ddlCreatedBy.Items.Add(new ListItem(row["newUserName"], row["numUserId"]));
            }
        }
    }
