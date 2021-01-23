     int firstCharPosition = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int lineNumber = richTextBox1.GetLineFromCharIndex(firstCharPosition);
            int lastCharPosition = richTextBox1.GetFirstCharIndexFromLine(lineNumber + 1);
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Select(firstCharPosition, lastCharPosition - firstCharPosition);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = "//" + richTextBox1.SelectedText.ToString();
            }
            else
            {
                string[] lines = richTextBox1.Text.Split(new string[] { Environment.NewLine, "\r", "\n", "\r\n" }, StringSplitOptions.None);
                string addedComments = "";
                for (int i = 0; i < lines.Length; i++) addedComments += "//" + lines[i] + Environment.NewLine;
                richTextBox1.Text = addedComments;
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Red;
            }
