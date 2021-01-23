    private void btnInsertRArtist_Click(object sender, EventArgs e)
        {
            SqlCommand comand = new SqlCommand("InsertRecordingArtists", conect);
            comand.CommandType = CommandType.StoredProcedure;
            try
            {
                if (txtboxRArtistName.Text == string.Empty || txtboxPlaceOB.Text == "")
                {
                    errorProvider1.SetError(txtboxRArtistName, "Enter the Music category");
                }
                else
                {
                    conect.Open();
                    comand.Parameters.AddWithValue("@RecordingArtistName", txtboxRArtistName.Text);
                    comand.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                    comand.Parameters.AddWithValue("@BirthPlace", txtboxPlaceOB.Text);
                    SqlDataAdapter adapt = new SqlDataAdapter(comand);
                    comand.ExecuteNonQuery();
                    txtboxRArtistName.Text = "";
                }
            }
            catch(Exception ex)
            {  
                  MessageBox.Show(ex.Message);
            }
            finally
            {
                conect.Close();
            }
        }
