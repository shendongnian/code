            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            var reader = new SqlCommand("select ID from Users", conn).ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "ID";
            comboBox1.DataSource = dt;
            conn.Close();
