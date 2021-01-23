       private void CheckTextBox(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }
