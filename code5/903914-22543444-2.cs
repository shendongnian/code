    conn.Open();
    MySqlDataReader myReader = cmd.ExecuteReader();
    while (myReader.Read())
    {          
        int value = myReader.GetInt32("Disponibilta")
        if(value < 30)
        {
            //do something
            MessageBox.Show("Attenzione alcuni prodotti sono in disponibilita' limitata!");
        }
    }
    myReader.Close();
    conn.Close();
