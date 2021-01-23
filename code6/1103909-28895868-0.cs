    private void commentOrUnComment(RichTextBox rtb, bool isUnComment)
    {
        if (rtb.Text.Length > 0 && rtb.SelectionLength >= 0)
        {
            string[] lines = rtb.Text.Split(new string[] { Environment.NewLine, "\n", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Color normalColor = Color.Black, commentColor = Color.Red;
            int selStart = rtb.SelectionStart, selEnd = selStart + rtb.SelectionLength,
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
                if (isUnComment)
                    lines[i] = (i >= startLine && i <= endLine ? (lines[i].TrimStart().StartsWith("//") ? lines[i].Substring(0, lines[i].IndexOf("//"))
                            + lines[i].Substring(lines[i].IndexOf("//") + 2) : lines[i]) : lines[i]);
                else
                    lines[i] = (i >= startLine && i <= endLine ? "//" : "") + lines[i];
            rtb.Text = "";
            rtb.SelectionStart = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                rtb.SelectionStart = rtb.Text.Length;
                rtb.SelectionColor = lines[i].TrimStart().StartsWith("//") ? commentColor : normalColor;
                rtb.SelectedText = lines[i] += (i == lines.Length - 1 ? "" : "\r\n");
            }
            int selectStarIndx = rtb.GetFirstCharIndexFromLine(startLine), selectEndIndx = rtb.GetFirstCharIndexFromLine(endLine + 1);
            if (selectEndIndx == -1) selectEndIndx = rtb.Text.Length;
            rtb.Select(selectStarIndx, selectEndIndx - selectStarIndx);
            rtb.Focus();
        }
    }
    private void btnComment_Click(object sender, EventArgs e)
    {
        commentOrUnComment(richTextBox1, false);
    }
    private void btnUncomment_Click(object sender, EventArgs e)
    {
        commentOrUnComment(richTextBox1, true);
    }
