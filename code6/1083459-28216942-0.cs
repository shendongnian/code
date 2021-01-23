        private void Delete()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM [Data] WHERE [ExpiredOn] <= @ExpiredOn";
                    conn.Open();
                    using (OleDbCommand command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ExpiredOn", UserInformation.Expired);
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an exception: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
