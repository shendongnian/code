      string ConString = " datasource = localhost; port = 3306; username = root; password = 3306";
      string Querry = "Select SUM(grade)/SUM(credits) FROM studentdata.semestre1";
      MySqlConnection ConDatabase = new MySqlConnection(ConString);
      MySqlCommand cmdDataBase = new MySqlCommand(Querry, ConDatabase);
      MySqlDataReader myReader;
      ConDatabase.Open();
      while ((myReader.Read()) && (myReader1.Read()))
            {
                textBox2.Text =Convert.ToString(double.Parse( myReader.GetString(0))) ;
            }
      myReader.Close();
     
