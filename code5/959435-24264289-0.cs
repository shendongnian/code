           double grades, credits;
           string ConString = " datasource = localhost; port = 3306; username = root; password = 3306";
           string Querry = " Select sum(grade) from studentdata.semestre1";
           string Querry1 = " Select sum(credit) from studentdata.semestre1";
           MySqlConnection ConDatabase = new MySqlConnection(ConString);
           
           ConDatabase.Open();
           using(MySqlDataReader myReader = cmdDataBase.ExecuteReader())
           {
              grades = double.Parse(myReader.GetString(0));
           }
    
           using(MySqlDataReader myReader1= cmdDataBase1.ExecuteReader())
           {
                credits = double.Parse(myReader1.GetString(0))) ;
           }
           ConDatabase.Close();
    
           textBox2.Text =Convert.ToString(grades/credits).ToString();
           
