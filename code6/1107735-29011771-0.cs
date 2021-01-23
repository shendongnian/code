    private void button1_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textBox2.Text)) 
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Ученики (Имя,Класс,Группа) values ('" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        else
        {
            MessageBox.Show("textbox2 was empty!");
        }
    }
