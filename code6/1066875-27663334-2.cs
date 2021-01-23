    void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Space)
        {
            e.SuppressKeyPress = true;
            int pos = t.SelectionStart;
            t.Text = t.Text.Substring(0, pos) + "|" + t.Text.Substring(pos);
            t.SelectionStart = pos + 1;   
        }
    }
