    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (Control control in this.Controls)
        {
            var textBox = control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += UpdateChartOnTextChange;
            }
        }
    }
