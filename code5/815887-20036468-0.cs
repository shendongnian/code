    private void button1_Click(object sender, EventArgs e)
    {
        if (username_txtb.Text == username && password_txtb.Text == password) //; - remove
        {
            MessageBox.Show("You are now logged in!");
        }
        else //; - remove
        {
            MessageBox.Show("Sorry, you have used the wrong username and password. Please try again.");
        }
    }
