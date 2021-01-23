    private void button1_Click(object sender, EventArgs e)
    {
        Form1 f1 = new Form1();
        f1.ShowDialog();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        Hide();
    }
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        MessageBox.Show("Closing");
    }
