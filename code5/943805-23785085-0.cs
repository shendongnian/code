    private void get_value_Click(object sender, EventArgs e)
        {
            for (i = 1; i <= 3; i++)
            {
                string value = this.flowLayoutPanel1.Controls["Text Box" + i].Text;
                richTextBox1.SelectedText  = "\r\n" + value;
            }
        }
