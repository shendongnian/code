        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "This" + Environment.NewLine + "A" + Environment.NewLine + "Multiline" + Environment.NewLine + "Textbox.";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(Environment.NewLine);
            textBox1.Focus();
        }
