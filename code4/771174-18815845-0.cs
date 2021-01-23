    private void DeleteDatabase(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)dataGridView1.DataSource;
        if (dt.Rows.Count > 0)
        {
            int rowNum = dataGridView1.CurrentRow.Index;
            int id = Convert.ToInt32(dt.DefaultView[rowNum]["ID"]);
            dt.DefaultView[rowNum].Delete();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM [Table] WHERE [ID] = @ID";
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            if (choice.comboBox1.Text == "English")
            { 
                System.Media.SoundPlayer sounds = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Exclamation.wav");
                sounds.Play();
                MessageBox.Show("Deleted Successfully!", "Deleted");
            }
        }
        else // count is 0
        {
            if (choice.comboBox1.Text == "English")
            {
                System.Media.SoundPlayer sounds = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Exclamation.wav");
                sounds.Play();
                MessageBox.Show("There is no Data in the Selected Row!", "Error");
                // return; (this return is redundant as we're at the end of the method.)
            }
        }
    }
