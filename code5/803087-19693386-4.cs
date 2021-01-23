    public bool ExistsKey(string keyField, string table, string value, SqlConnection con){      
      try {
       if(con.State != ConnectionState.Open) con.Open();
       using(SqlCommand com = new SqlCommand(
                    string.Format("IF EXISTS(SELECT * FROM {0} WHERE {1}='{2}') SELECT 1 ELSE SELECT 0", 
                                 table, keyField, value), con)){
         var result = com.ExecuteScalar();
         return result != null && (int)result == 1;
       }
      } catch {
        return false;
      }
      finally {
        con.Close();
      }      
    }
    //Then use that method in your code like this:
    if(ExistsKey("idnum", "TableVotersInfo", _idnum.ToString(), sc)){
      MessageBox.Show("ID number already exist!");
      FAddVoters._cleardata = "0";
      FAddVoters._checkID = checkID;
    } else {
      //perform your update here ...
    }
