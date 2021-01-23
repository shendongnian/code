    private void Log(string text)
    {
        log.AppendLine(text);
        if (lbOut.InvokeRequired)
        {
            lbOut.Invoke((MethodInvoker)delegate()
            {
                lbOut.Items.Add(text);
            });
        }
        else
        {
            lbOut.Items.Add(text);
        }
    }
