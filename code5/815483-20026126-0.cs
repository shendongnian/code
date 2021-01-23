    {
            MySqlConnection cs = new MySqlConnection(@"Data Source = 000.000.00.000;username=*******;password=******; Initial Catalog = database; Integrated Security = true");
           MySqlDataAdapter da = new MySqlDataAdapter ();
            da.InsertCommand = new MySqlCommand("INSERT INTO Customer(FirstName,LastName) VALUES (@FirstName,@LastName)", cs);
            da.InsertCommand.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = firstname.Text;
            da.InsertCommand.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = lastname.Text;
            cs.Open();
            da.InsertCommand.ExecuteNonQuery(); 
            cs.Close();
        }
