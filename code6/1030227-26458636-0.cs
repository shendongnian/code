    private void button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(TextBox1.Text) == montH)
        {
            MessageBox.Show("You Win!!");
        }
        else
        {
            MessageBox.Show("You Lose...");
        }
    }
