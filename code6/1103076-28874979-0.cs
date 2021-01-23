    if (richTextBox1.Text.Length > 0 && richTextBox1.SelectionLength >= 0)
        {
            string[] lines = richTextBox1.Text.Split(new string[] { Environment.NewLine, "\n", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Color normalColor = Color.Black, commentColor = Color.Red;
            int selStart = richTextBox1.SelectionStart, selEnd = selStart + richTextBox1.SelectionLength,
            startLine = -1, endLine = -1, lineSum = 0, k = 0;
            for (k = 0; k < lines.Length; k++)
                if (startLine == -1)
                {
                    if ((lineSum += lines[k].Length + 1) > selStart)
                    {
                        startLine = k;
                        if (selEnd <= lineSum) endLine = k;
                    }
                }
                else if (endLine == -1)
                {
                    if ((lineSum += lines[k].Length + 1) >= selEnd)
                        endLine = k;
                }
                else break;
            for (int i = 0; i < lines.Length; i++)
                lines[i] = (i >= startLine && i <= endLine ? "//" : "") + lines[i];
            richTextBox1.Text = "";
            richTextBox1.SelectionStart = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = lines[i].TrimStart().StartsWith("//") ? commentColor : normalColor;
                richTextBox1.SelectedText = lines[i] += (i == lines.Length - 1 ? "" : "\r\n");
            }
            int selectStarIndx = richTextBox1.GetFirstCharIndexFromLine(startLine), selectEndIndx = richTextBox1.GetFirstCharIndexFromLine(endLine + 1);
            if (selectEndIndx == -1) selectEndIndx = richTextBox1.Text.Length;
            richTextBox1.Select(selectStarIndx, selectEndIndx - selectStarIndx);
            richTextBox1.Focus();
        }
