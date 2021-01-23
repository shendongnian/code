            connection = new SqlConnection(connectionString);
            connection.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM your_table WHERE first_name = " + your_first_name;
            cmd.Connection = connection;
            rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                txtSurname.Text = rdr["Surname"].ToString();
                txtJobTitle.Text = rdr["JobTitle"].ToString();
                txtDepartment.Text = rdr["Department"].ToString();
            }
            cmd.Dispose();
            connection.Close();
            return infos;
