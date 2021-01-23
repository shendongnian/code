    // log is defined above as a StringBuilder
    hook.KeyUp += (s, e) =>
        {
            if (e.KeyData.ToString() == "Space")
            {
                log.Append(" ");
            }
            else
            {
                log.Append(e.KeyData.ToString());
            }
            textLogs.Text = log.ToString();
        };
