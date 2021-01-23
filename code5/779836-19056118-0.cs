    private void button1_Click(object sender, EventArgs e) //Save button
        {
            try
            {
                cnn.Open();
                string path = pictureBox1.ImageLocation; // this will work
                string path = pictureBox1.Image.ToString(); // here error comes
                Byte[] imagedata = File.ReadAllBytes(path);
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (EmployeeFirstname, EmployeeLastname, EmployeePhoto) VALUES (@item1,@item2,@img", cnn);
                cmd.Parameters.AddWithValue("@item1", textBox1.Text);
                cmd.Parameters.AddWithValue("@item2", textBox2.Text);
                cmd.Parameters.AddWithValue("@img", imagedata);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
