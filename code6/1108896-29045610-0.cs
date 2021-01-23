    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 5)
            {
                pictureBox1.ImageLocation = @"ximagelocalion";                
            }
            else
            {
                pictureBox1.ImageLocation = @"checkimagelocalion";
            }
        }
