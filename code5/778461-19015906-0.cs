        public void ChangePass()
        {
            // Not very important, but this doesn't need to be in the try/catch
            if (_oldpass == "" || _newpass == "" || _conpass == "")
            {
                var message = "Must fill up all the fields!";
                var title = "Voting System Error Message";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                sc.Open();
                // SqlCommand, SqlDataReader, and anything else you create that implements
                // IDisposable, needs to be in a using block
                using (var cmd = new SqlCommand("SELECT password FROM TableLogin WHERE password = @Password", sc))
                {
                    // As others have said, use parameters to avoid SQL Injection Attacks
                    cmd.Parameters.AddWithValue("@Password", _oldpass);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // You don't need == true
                        {
                            if (_newpass == _conpass)
                            {
                                // Separate SqlCommand and use a using block
                                using (
                                    var updateCommand =
                                        new SqlCommand(
                                            "UPDATE TableLogin SET password = @Password WHERE username = 'admin'",
                                            sc))
                                {
                                    // and a parameter
                                    updateCommand.Parameters.AddWithValue("@Password", _newpass);
                                    // Use ExecuteNonQuery, and check affected rows
                                    var rowsAffected = updateCommand.ExecuteNonQuery();
                                    if (rowsAffected == 1)
                                    {
                                        MessageBox.Show("Successfully Changed!");
                                    }
                                }
                            }
                            else
                            {
                                var message = "New Password and Confirm Password does not match!";
                                var title = "Voting System Error Message";
                                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            var message = "Wrong Old Password!";
                            var title = "Voting System Error Message";
                            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // For troubleshooting purposes, display the entire exception
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.Close();
            }
        }
