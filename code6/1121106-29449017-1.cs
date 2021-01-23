    private void Form1_Load(object sender, EventArgs e)
    {
        LongClick.Attach(button1, button1_LongClick);
    }
    private void button1_LongClick(object sender, EventArgs e)
    {
        MessageBox.Show("button1 long clicked!");
    }
