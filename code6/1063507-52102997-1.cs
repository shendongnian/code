    class UserDAO
    {
        public void UpdateUser(User user)
        {
            int result = -1;
            string connectionString = "Data Source=C:\\Counter\\Counter.sqlite";
            lock (ConnectionManager.instanceLock)
            {
                using (SQLiteConnection conn = ConnectionManager.CreateConnection(connectionString))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "UPDATE counter_user " +
                            "SET runnerfirstname=@runnerfirstname, " +
                            "runnerlastname=@runnerlastname, " +
                            "parentlastname=@parentlastname, " +
                            "parentfirstname=@parentfirstname, " +
                            "runnergrade=@runnergrade, " +
                            "email=@email, " +
                            "laps=@laps, " +
                            "vestnumber=@vestnumber, " +
                            "tagid=@tagid " +
                            "WHERE id=@id";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@runnerfirstname", user.RunnerFirstName);
                        cmd.Parameters.AddWithValue("@runnerlastname", user.RunnerLastName);
                        cmd.Parameters.AddWithValue("@parentlastname", user.ParentLastName);
                        cmd.Parameters.AddWithValue("@parentfirstname", user.ParentFirstName);
                        cmd.Parameters.AddWithValue("@runnergrade", user.RunnerGrade);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@laps", user.Laps);
                        cmd.Parameters.AddWithValue("@vestnumber", user.VestNumber);
                        cmd.Parameters.AddWithValue("@tagid", user.TagId);
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Console.WriteLine("test");
                        }
                    }
                    conn.Close();
                }
            }
        }
    
