                 private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;
            int x = lines.Length;
            if(x>100)
            {
               richTextBox1.Lines = richTextBox1.Lines.Skip(x - 100).ToArray();
               richTextBox1.ScrollToCaret();
               richTextBox1.Select(richTextBox1.Text.Length, 0);
            }
        }
