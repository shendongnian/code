    List<listData> Emaillist = new List<listData>();
    
    while (sqlData.Read())
    {
        listData itemData = new listData();
        itemData.email = sqlData[0].ToString();
        itemData.email_header = sqlData[1].ToString();
        itemData.email_body = sqlData[2].ToString();
        itemData.email_guid = sqlData[3].ToString();
        Emaillist.Add(itemData);                
    }
