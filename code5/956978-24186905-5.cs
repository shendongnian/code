    private void textBox1_TextChanged(object sender, EventArgs e)
    {
            string checkstr = textBox1.Text;
            char[] checkchar = checkstr.ToCharArray();
            char[] newchar = new char[checkstr.Length];
            int pos = 0;
            for (int i = 0; i < checkstr.Length; i++)
            {
                if (Char.IsLetter(checkchar[i]))
                {
                    newchar[pos] = checkchar[i];
                    pos++;
                }
            }
            checkstr = String.Join("", newchar);
            if (textBox1.Text != checkstr)
            {
                var start = textBox1.SelectionStart;
                textBox1.Text = checkstr;
                textBox1.SelectionStart = start;
            }
    }
