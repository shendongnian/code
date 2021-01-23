    private void button1_Click(object sender, EventArgs e)
    {
        string username = "Admin";
        string password = "root";
    
        if (string.IsNullOrWhiteSpace (textBox1.Text))
            MessageBox.Show("No Password inserted");
        else if (string.IsNullOrWhiteSpace (textBox2.Text))
            MessageBox.Show("No username inserted");
        else if ((textBox1.Text == username) && (textBox2.Text == password))
            MessageBox.Show("Login Succeed");
        else
            MessageBox.Show("Login failed");
    
    }
