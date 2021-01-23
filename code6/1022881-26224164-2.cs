    con.Open();
    List<MyTableModel> DataBind = new List<MyTableModel>();
    cmd.CommandText = "SELECT Id, value FROM MyTable";
    _DataReader = cmd.ExecuteReader();
    if(_DataReader.HasRows) {
       while(_DataReader.Read()){
          DataBind.Add(new MyTableModel() {Id = _DataReader.GetInt(0), value =_DataReader.GetString(1) });
       }
    }
    con.Close();
