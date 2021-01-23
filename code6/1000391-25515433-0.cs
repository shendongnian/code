    static public void SaveScore(string username, string score) {
            try {
                DatabaseConnection db = new DatabaseConnection();
                db.Connection.Open();
                var cmd = db.GetCommand("SELECT Score FROM Users WHERE Username = username");
                var oldScore = Convert.ToInt32(cmd.ExecuteScalar());
                var value = Int32.Parse(score);
                if (oldScore < value) {
                    cmd = db.GetCommand("UPDATE Users SET Score = @score WHERE Username = @username AND Score < @score");
                    cmd.Parameters.AddWithValue("@score", value);
                    cmd.Parameters.AddWithValue("@username", username);
                    MessageBox.Show("New High Score Was Saved","Congratulations",MessageBoxButtons.OK);
                }
                else {
                    MessageBox.Show("High Score Wasn't Reached. Try Again", "Game Over", MessageBoxButtons.OK);
                }
                cmd.ExecuteNonQuery();
                db.Connection.Close();                
            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }
