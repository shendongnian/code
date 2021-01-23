	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeText();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        changeText();
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        changeText();
    }
    private void changeText()
    {
        if (comboBox1.SelectedItem.ToString() == "Man")
            label1.Text = "Geachte heer " + textBox1.Text + " " + textBox2.Text;
        else
            label1.Text = "Geachte mevrouw " + textBox1.Text + " " + textBox2.Text;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Text = "";
        comboBox1.Items.Add("Man");
        comboBox1.Items.Add("Woman");
        comboBox1.SelectedIndex = 0;
    }
