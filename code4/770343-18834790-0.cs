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
            txtLog.Text += Environment.NewLine + text;
        }
