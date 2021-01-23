        IList<int> ids = new List<int>();
        private async void doWork()
        {
            var connection = new SqlConnection(...);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT registrationId FROM someTable", connection);
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    ids.Add(reader.GetInt32(reader.GetOrdinal("RegistrationId")));
                }
                reader.Close();
                //heavy database operations
                // Part 1 of whatever GetRegistrationsByIds does would go into GetRegistrationReader().
                var registrationReader = await Task.Run(() => GetRegistrationReader(connection, ids));
                // Part 2 of whatever GetRegistrationsByIds does for each 
                // Registration would go into GetRegistrations().
                var registrationEnumerator = GetRegistrations(orderReader);
                foreach (var registration in registrationEnumerator)
                {
                    // Do whatever you need to do for each registration
                    listBox1.Items.Add(registration.Id);
                }
            }
        }
        private IEnumerable<Registration> GetRegistrations(SqlDataReader reader)
        {
            while (reader.Read())
            {
                // You would do whatever you need to do to each registration here.
                var registration = new Registration{ Id = reader.GetInt32(reader.GetOrdinal("RegistrationId")) };
                yield return registration;
            }
        }
        private SqlDataReader GetRegistrationReader(SqlConnection connection, IList<int> ints)
        {
            // Some query that returns a lot of rows.
            // Ideally it would written to stream directly from the 
            // database server, rather than buffer the data to the client
            // side.
            SqlCommand command = new SqlCommand("SELECT * from registrations", connection);
            return command.ExecuteReader();
        }
        internal class Registration
        {
            public int Id;
            // ... other fields, etc.
        }
