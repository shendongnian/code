            string[number_of_infos] infos = null;
            connection = new SqlConnection(connectionString);
            connection.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM your_table WHERE first_name = " + your_first_name;
            cmd.Connection = connection;
            rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                infos[0] = rdr["Surname"].ToString();
                infos[1] = rdr["JobTitle"].ToString();
                infos[2] = rdr["Department"].ToString();
            }
            cmd.Dispose();
            connection.Close();
            return infos;
