    foreach(var crTable in doc.Database.Tables) {
        crystalTableLogOnInfo = crTable.LogOnInfo;
    
        crystalTableLogOnInfo.ConnectionInfo.ServerName = strDSNName;
        crystalTableLogOnInfo.ConnectionInfo.DatabaseName = strDBName;
        crystalTableLogOnInfo.ConnectionInfo.UserID = strUserName;
        crystalTableLogOnInfo.ConnectionInfo.Password = strPassword;
        crystalTableLogOnInfo.TableName = crTable.Name; // this line
        crTable.ApplyLogOnInfo(crystalTableLogOnInfo);
        crTable.Location = crTable.Name;                // and this line
    }
    
    doc.VerifyDatabase();
