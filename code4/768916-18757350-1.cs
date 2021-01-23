    List<string> lstTypeName = new List<string>();
    while (sqldrAllData.Read())
    {
        lstTypeName.Add(sqldrAllData["TypeName"].ToString().Substring(0, '.'));
    }
