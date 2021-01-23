    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (username_txtb.Text == username && password_txtb.Text == password)
        {
            MessageBox.Show("You are now logged in!");
        }
        else
        {
            MessageBox.Show("You have entered an incorrect username or password!");
        }
    }
}
