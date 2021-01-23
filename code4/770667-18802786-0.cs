        private void Delete(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int rowNum = dataGridView1.CurrentCellAddress.Y;
            int id = Convert.ToInt32(dt.DefaultView[rowNum]["ID"]);
            //check if row is empty, simply return
            if(IsRowEmpty(id)){
              System.Media.SoundPlayer sounds = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Exclamation.wav");
              sounds.Play();
              MessageBox.Show("There is no data in the selected row", "Error");
              return;
            }
            //Remove the row
            dt.DefaultView[rowNum].Delete();
            dt.AcceptChanges(); //<-- Because you don't use Adapter, call this to restore the row state.
            //Remove the underlying row in database
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM [Table] WHERE [ID] = @ID";
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                if (choice.comboBox1.Text == "English")
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Exclamation.wav");
                    sound.Play();
                    MessageBox.Show("Deleted Successfully!", "Deleted");                    
                }
             }
        }
        //method to check if a row is empty
        private bool IsRowEmpty(int index){
           return dataGridView1.Rows[index].Cells.OfType<DataGridViewCell>()
                                           .All(c=>c.Value == null);
        }
