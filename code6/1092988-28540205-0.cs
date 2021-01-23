    private void TextBox1KeyDown(object sender, KeyEventArgs e)
        {
            int i;
 
            string s = string.Empty;
 
            s += (char)e.KeyValue;
 
             if (!(int.TryParse(s, out i)))
            {
                e.SuppressKeyPress = true;
            }
            else if(e.KeyCode == Keys.T || e.KeyCode == Keys.M)
            {
                e.SuppressKeyPress = true;
                Button1Click(this, EventArgs.Empty);
            }             
        }
