    for(x = 0; x < listBoxControl2.Items.Count; x++)
    {
        
        while(sqlDataReader.Read())
        {
            DateTime login = sqlDataReader.GetDateTime(0);
            DateTime logout = sqlDataReader.GetDateTime(1);
            if (login > logout)
            {
                listBoxControl2.Items[x] = listBoxControl2.Items[x] + " connected";
            }
            else
            {
                listBoxControl2.Items[x] = listBoxControl2.Items[x] + " logged off";
            }
        }
    }
