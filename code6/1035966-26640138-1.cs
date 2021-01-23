    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var button in Controls.OfType<Button>())
        {
            button.Click += button_Click;
        }
    }
    void button_Click(object sender, EventArgs e)
    {
        ((Control) sender).Visible = false;
    }
