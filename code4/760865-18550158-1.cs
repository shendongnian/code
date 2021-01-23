        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    textBox1.SelectAll();
                }
                if (e.KeyCode == Keys.Back)
                {
                    e.SuppressKeyPress = true;
                    int selStart = textBox1.SelectionStart;
                    while (selStart > 0 && textBox1.Text.Substring(selStart - 1, 1) == " ")
                    {
                        selStart--;
                    }
                    int prevSpacePos = -1;
                    if (selStart != 0)
                    {
                        prevSpacePos = textBox1.Text.LastIndexOf(' ', selStart - 1);
                    }
                    textBox1.Select(prevSpacePos + 1, textBox1.SelectionStart - prevSpacePos - 1);
                    textBox1.SelectedText = "";
                }
            }
        }
