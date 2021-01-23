        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //cod for run
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textbox1_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }
