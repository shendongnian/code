    SQLConnection dbConn = new SQLConnection("server=serverName,database=karticeM");
    dbConn.Open();
    SQLCommand query = new SQLCommand("SELECT SUM(Transaction) FROM whateverTableName");
    query.Connection = dbConn;
    Int sum = query.ExecuteScalar();
    ammountlbl.Text = sum.ToString();
