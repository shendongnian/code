    //dont foget to use this at the top of the page
    using System.Text.RegularExpressions;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string find = "while";
            if (richTextBox1.Text.Contains(find))
            {
                var matchString = Regex.Escape(find);
                foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
                {
                richTextBox1.Select(match.Index, find.Length);
                richTextBox1.SelectionColor = Color.Aqua;
                richTextBox1.Select(richTextBox1.TextLength, 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                };
            }
        }
