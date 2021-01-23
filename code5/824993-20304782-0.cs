    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=rootpassword";
            string Query = "select * from database2.employee where id=@id ORDER BY Auto  ;";
                    
            MySqlConnection conDataBase = new MySqlConnection(constring);
            conDataBase.Parameters.AddWithValue("@id",comboBox1.SelectedItem.ToString());
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader=cmdDataBase.ExecuteReader();
            if(myReader.Read())
           {
              TextBox1.Text=myReader["ID"].ToString() +" - "+myReader["name"].ToString();
            }
          conDataBase.Close();
        }
