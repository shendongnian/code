    private void MainPage_Load(object sender, EventArgs e)
    {
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            // your code to go to the other page.
        }
    }
