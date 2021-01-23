    private void Form1_Load(object sender, EventArgs e)
    {
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem == "Circle")
        {
            pictureBox1.Image = circle;
        }
    }
