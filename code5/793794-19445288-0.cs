    private int _currentRecordId = -1;
    ...
    string cmdStr = String.Format("SELECT * FROM Table WHERE id > {0} ORDER BY id LIMIT 1", _currentRecordId);
    using (var con = new OleDbConnection(constr))
    using (var com = new OleDbCommand(cmdStr, con))
    {
        con.Open();
        using(var reader = com.ExecuteReader())
        {
            while (reader.Read())
            {
                _currentRecordId = reader.GetInt32(0); // whatever field the id column is
                // populate fields
            }
        }
    }
