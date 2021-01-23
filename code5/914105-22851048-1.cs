        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Visible = false;
                textBox1.Visible = true;
                textBox1.Text = "Welcome1";
            }
        }
