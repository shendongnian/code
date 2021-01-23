       private void txtNex_TextChanged(object sender, EventArgs e)
       {
            string text = txtNex.Text;
            string loopText = txtNex.Text;
            foreach (Char c in loopText)
            {
                string s1 = c.ToString();
                if(Regex.IsMatch(s1, "[^0-9]"))
                {
                    if (text.Contains(s1))
                        text = text.Replace(s1, "");
                }
            }
            txtNex.Text = text;
       }
