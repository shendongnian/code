    string myConnection =  datasource=localhost;port=3306;username=encrypti_dropem;password=PASSWORD";       
            MySqlConnection myCon = new MySqlConnection(myConnection);
            MySqlCommand SelectCommand = new MySqlCommand("select * from         encrypti_dropem.users where username='" + label9.Text + "';", myCon);
            MySqlDataReader reader2;
            myCon.Open();
            reader2 = SelectCommand.ExecuteReader();
            while (reader2.Read())
            {
                Session["rankid"] = reader2.GetString("rank");              
            }
            myCon.Close();
