    using (MySqlConnection conn = DB.conn_f()) {
      using (MySqlDataReader rdr = DB.CMD_f(conn, "SELECT * FROM tbl_kategorie")) {
        int i = 0;
        while (rdr.Read()) {
          string str = rdr.GetString(1);
          Console.WriteLine(str);
        }
      }
    }
