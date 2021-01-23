    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sVal = textBox1.Text;            
            if (!string.IsNullOrEmpty(sVal))
            {
                sVal = sVal.Replace("-", "");
                string newst = Regex.Replace(sVal, ".{2}", "$0-");
                textBox1.Text = newst;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
