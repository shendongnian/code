    using (SqlDataReader reader1 = cmd.ExecuteReader())
    {
        while (reader1.Read())
        {
            int numUserID = reader1.GetInt32(1);
            string strFirstName = reader1.GetString(3);
            string strLastName = reader1.GetString(4);
            string newUserName = strFirstName + " " + strLastName;
    
            ddlCreatedBy.Items.Add(new ListItem(newUserName, numUserId.ToString()));
        }
    }
