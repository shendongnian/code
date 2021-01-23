     private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "\r\n\r\n"+"          "+ textBox1.Text; // Appended Spaces
            richTextBox1.Font = new Font("Comic Sans MS", 14);
        }
