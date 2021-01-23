    private void Save_button1_Click(object sender, EventArgs e)
            {
                try
                {
                    string movieName = Name_textBox1.Text;
                    string folderLocation = location_textBox2.Text;
    
                    String query = "INSERT INTO movie(Name ,Location ) VALUES(@movieName,@folderLocation)";
                    op.Parameters.AddWithValue("@movieName",movieName);
                    op.Parameters.AddWithValue("@folderLocation",folderLocation);
                    op.SaveInformation(query);
                    op.Load_Table1(dataGridView1);
    
    
                    Name_textBox1.Text= "";
                   location_textBox2.Text= "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
