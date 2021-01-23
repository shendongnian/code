    private void Form1_Load(object sender, EventArgs e)
    {
        panel1.Controls.OfType<Label>().ToList().ForEach(l => l.Click += label_Click);
    }
    private void label_Click(object sender, EventArgs e)
    {
        ChangeToTextbox(sender);
    }
