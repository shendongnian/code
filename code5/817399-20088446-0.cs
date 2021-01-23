    private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Validating(sender);
        }
        public void textBox1_Validating(object sender)
        {
            MessageBox.Show("validating");
            errorProvider1.SetError(textBox1, "provide");
        }
