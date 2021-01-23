    using (var myConn = new MySqlConnection(myConnection))
    using (var Login = new MySqlCommand("select * from database.users where Username= @myUserName", 
           myConn);
    {
      cmdDataBase.AddWithValue(new MySqlParameter("@myUserName", this.UsernameRegister.Text));
      conDataBase.Open();
      using (var myReader = cmdDataBase.ExecuteReader())
      {
          while (myReader.Read())  *** Now you are trying to Read!
          {
               // Do something with myReader[] fields here
          }
      }
    }
