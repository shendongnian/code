        int token = -1;
        int token2 = -1;
      
        richTextBox1.Text = richTextBox1.Text.Replace(" <", "<");
        richTextBox1.Text = richTextBox1.Text.Replace("< ", "<");
        richTextBox1.Text = richTextBox1.Text.Replace(" >", ">");
        richTextBox1.Text = richTextBox1.Text.Replace("> ", ">");
        while (richTextBox1.Text.IndexOf("<i>") > -1)
        {
          token = richTextBox1.Text.IndexOf("<i>");
          token2 = richTextBox1.Text.IndexOf("</i>", token) + 4;
          string clip = richTextBox1.Text.Substring(token, token2 - token);
          Font italicFont = new Font("Cambira", 14, FontStyle.Italic);
          richTextBox1.Select(token, token2 - token);
          richTextBox1.SelectionFont = italicFont;
          richTextBox1.SelectedText = " " + clip.Replace("<i>", "").Replace("</i>", "") + " ";
        }
