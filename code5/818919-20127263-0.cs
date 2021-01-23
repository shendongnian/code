        private void Form1_Shown(object sender, EventArgs e)
        {
            string ctlNameFromDatabase = "textBox1";
            Control[] matches = this.Controls.Find(ctlNameFromDatabase, true);
            if (matches.Length > 0)
            {
                // ... do something with "matches[0]" ...
                // you may need to CAST to a specific type:
                if (matches[0] is TextBox)
                {
                    TextBox tb = matches[0] as TextBox;
                    tb.Text = "Hello!";
                }
            }
            else
            {
                MessageBox.Show("Name: " + ctlNameFromDatabase, "Control Not Found!");
            }
        }
