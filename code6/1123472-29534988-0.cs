        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand(@"UPDATE Tcostumers
                                                        SET cfname = @CFName,
                                                            clname = @CLName
                                                        WHERE cid = @CID", connect);
            command.Parameters.AddWithValue("@CFName", textBox2.Text);
            command.Parameters.AddWithValue("@CLName", textBox3.Text);
            command.Parameters.AddWithValue("@CID", textBox1.Text);
            try
            {
                connect.Open();
            }
            catch (Exception expe)
            {
                MessageBox.Show(expe.Source);
            }
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("DATA UPDATED");
            }
            catch (Exception expe)
            {
                MessageBox.Show(expe.Source);
            }
            finally
            {
                connect.Close();
            }
        }
