    public bool ExistsKey(string rowID, string keyField, string table, string value, SqlConnection con)
    {      
        try 
        {
            if(con.State != ConnectionState.Open) con.Open();
            using(SqlCommand com = new SqlCommand(
            string.Format("IF EXISTS(SELECT * FROM {0} WHERE {1}='{2}' AND id <> '{3}') SELECT 1 ELSE SELECT 0", 
                     table, keyField, value, rowID), con))
            {
                var result = com.ExecuteScalar();
                return result != null && (int)result == 1;
            }
        } 
        catch 
        {
            return false;
        }
        finally 
        {
            con.Close();
        }      
    }
    //Then use it like this:
    if (ExistsKey(_id.ToString(), "idnum", "TableVotersInfo", _idnum.ToString(), sc)) {
        MessageBox.Show("ID number already exist!");
        FAddVoters._cleardata = "0";
        FAddVoters._checkID = checkID;
    }
