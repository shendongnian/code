    private void Form1_Load(object sender, EventArgs e)
    {
        // Dynamically hook up all the TextBox TextChanged events to your custom method
        foreach (Control control in this.Controls)
        {
            var textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }
    }
