    public void ToDatabase(string Database, string Table, DataTable Datatable) {
      string query = "SELECT * FROM `" + Database + "`.`" + Table + "`;";
      if (this.OpenConnection()) {
         MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
         MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
         adapter.Update(Datatable);
         this.CloseConnection();
      }
    }
