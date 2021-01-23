            string connector_string = "datasource = localhost;port=3306;username=root;password=;";
            MySqlConnection sqlcon = new MySqlConnection(connector_string);
            sqlcon.Open();
            string query = string.Format("Select * from oep.quiz where que like '%{0}%'", txt_Searchque.Text);
            MySqlCommand cmd = new MySqlCommand(query, sqlcon);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
