    com.CommandText = ("INSERT INTO SMSArchives(Message,Blacklist) VALUES (@Message, @Blacklist)");
    SqlParameter messageParam = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 8000);
    SqlParameter blacklistParam = new SqlParameter("@Blacklist", System.Data.SqlDbType.VarChar, 10);
    messageParam.Value = message.ToString();
    blacklistParam.Value = "Yes";
    com.Parameters.Add(messageParam);
    com.Parameters.Add(blacklistParam);
    com.ExecuteNonQuery();
