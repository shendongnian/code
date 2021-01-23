    bool _hasWhere;
    private string GetSelectSql()
    {
        string sql = "Select ...... From .... "; // also, make sql a StringBuilder
    
        if (txtLastName.Text.Trim() != string.empty)
        {
            if (SetWhere()) 
                sql += " Where ";
            else 
               sql += ",";  
            sql += string.Format(" LastName like '%{0}%' ", txtLastName);
        }
        if (txtFirstName.Text.Trim() != string.empty)
        {
            if (SetWhere()) 
               sql += " Where ";
            else 
               sql += ",";  
            sql += string.Format(" FirstName like '%{0}%' ", txtLastName);
        }
        // keep on going here .................
        return sql;
    }
    private bool SetWhere()
    {
        if (!hasWhere) 
        {
           hasWhere = true;
           return true;
        }
        return false;
    }
    private SqlCommand CreateCommand (string sql)
    {
        .............
        SqlCommand command = new Sqlcommand(sql,....
        .............
        return Command
     }
