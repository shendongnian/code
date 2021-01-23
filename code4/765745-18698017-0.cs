    string conStr = @"Data Source=PathAndNameOFSdfFile.sdf";
    SqlCeDataReader sqldrAllData;
    SqlCeConnection sqlCon = new SqlCeConnection(conStr);
    SqlCeCommand sqlCmd = new SqlCeCommand("Select TypeName, Syntax From tb_CsType", sqlCon);
    sqlCon.Open();
    sqldrAllData = sqlCmd.ExecuteReader();
    while(sqldrAllData.Read())
    {
        KeywordTipTexts.Add(sqldrAllData["TypeName"].ToString(), sqldrAllData["Syntax"].ToString());
    }
    sqlCon.Close();
