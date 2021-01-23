       public void UpdateTable(DataSet ds)
        {
            using (MySqlConnection connect = new MySqlConnection(ConnString))
            {
                connect.Open();
                MySqlCommandBuilder commbuilder = new MySqlCommandBuilder(adapt);
                adapt.SelectCommand = new MySqlCommand("SELECT * FROM t_receipients", connect);
                adapt.Update(ds.Tables[0]); 
            }
        }
