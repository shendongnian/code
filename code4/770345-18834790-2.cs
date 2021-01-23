        if (chkAutoScroll.Checked)
        {
            // This always auto scrolls to the bottom.
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText(text);
            // This always auto scrolls to the top.
            //txtLog.Text += Environment.NewLine + text;
        }
        else
        {
            int caretPos = txtLog.Text.Length;
            txtLog.Text += Environment.NewLine + text;
            txtLog.Select(caretPos, 0);            
            txtLog.ScrollToLine(txtLog.GetLineIndexFromCharacterIndex(caretPos));
        }
