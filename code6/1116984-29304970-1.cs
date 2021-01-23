    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ElearningConnectionString2);
            string sc;
            SqlCommand cmd;
            sc = "INSERT INTO tblUserAnswers (UserId, QuizDate, score) values (@UserId, @GETDATE(), @Score)";              
             cmd = new SqlCommand(sc, conn);
             cmd.Parameters.AddWithValue("@UserId", Globals.currentUserId);
             cmd.Parameters.AddWithValue("@QuizDate", DateTime.Now);
             cmd.Parameters.AddWithValue("@Score", score);
            conn.Open();
            int re = cmd.ExecuteNonQuery();
            conn.Close();
            if (re == 1)
            {
                MessageBox.Show("Record saved");
            }
