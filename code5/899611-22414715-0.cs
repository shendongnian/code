        string constring = "datasource=localhost;port=3306;username=root;password=";
        string Query = "Select ocena From filmi.film Where film = @film"; ;
        using(MySqlConnection conDataBase = new MySqlConnection(constring))
        using(MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
        {
            try
            {
                conDataBase.Open();
                cmdDataBase.Parameters.AddWithValue("@film", this.comboBox1.SelectedItem);
                using(MySqlDataReader myReader = cmdDataBase.ExecuteReader())
                {
                   while (myReader.Read())
                   {
                       string ocenaValue = (myReader.IsDbNull(myReader.GetOrdinal("ocena")) ?
                                           string.Empty, myReader["ocena"].ToString());
                       listBox2.Items.Add(ocenaValue);
                    }
                }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
