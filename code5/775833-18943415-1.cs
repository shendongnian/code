        private void text_Leave(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text.Length >= 1)
            {
                text.Text = text.Text.Substring(0, 1).ToUpper() + text.Text.Substring(1
            }
        }
