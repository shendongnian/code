    private void Page_Load(object sender, EventArgs e)
    {
    	Button1.Attributes.Add("onClick", "javascript:checkTextBoxEmpty();")
    }
    
    private void Button1_Click(object sender, EventArgs e)
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
