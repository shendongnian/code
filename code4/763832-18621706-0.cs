            const string sqlSelect = @"SELECT ... WHERE akce=@akce";
            using (spojeni = new SqlConnection(connectionString)) 
            using(var command = new SqlCommand(sqlSelect,spojeni))
            {
                command.Parameters.AddWithValue("@akce", zakce.Text);
                command.Connection.Open();
                object vysledek2 = command.ExecuteScalar();
            }
