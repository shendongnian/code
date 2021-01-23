    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        int index = textBox1.SelectionStart;
        if(glbin.ContainsKey(e.KeyChar))
        {
          var txt = textBox1.Text; // insert both chars at once
          textBox1.Text = txt.Insert(index, e.KeyChar + glbin[e.KeyChar].ToString());
          textBox1.Select(index + 1, 0);// position cursor inside brackets
          e.Handled = true;
        }
        else if (glbin.Values.Contains(e.KeyChar))
        {
          // move cursor forward ignoring typed char
          textBox1.SelectionStart = textBox1.SelectionStart + 1;
          e.Handled = true;
        }
    }
