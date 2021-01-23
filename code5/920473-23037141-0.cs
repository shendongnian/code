    if (e.KeyChar == (char)Keys.Enter)
    {
         richTextBox1.AppendText("\t");
         
          // Edited After Comment
         var PrevLine = richTextBox2.Lines[richTextBox2.Lines.Count() - 1].ToString();
         var TabsCount = System.Text.RegularExpressions.Regex.Matches(PrevLine, "\t").Count;
    }
