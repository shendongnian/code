    List<string> sqlstrings = new List<string>();
    DataSet dataset = new DataSet();
  
    for(int i = 0; i < sqlstrings.count; i++)
    {
        OracleDataAdapter adapter = new OracleDataAdapter(sqlstrings[i].ToString(), conn);
        OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
        
        adapter.Fill(dataset.Tables[i]);
    }
