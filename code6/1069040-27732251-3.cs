    using (var myConn = new MySqlConnection(myConnection))
    using (var Login = new MySqlCommand("select * from database.users where Username= @myUserName", 
           myConn);
    {
      cmdDataBase.AddWithValue(new MySqlParameter("@myUserName", this.UsernameRegister.Text));
      conDataBase.Open();
      using (var myReader = cmdDataBase.ExecuteReader())
      {
          while (myReader.Read())
          {
               // Do something with myReader[] fields here
          }
      } // Reader disposed
    } // Command Disposed, Connection Closed + Disposed
