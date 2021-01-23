    private void CheckAccessTime(object sender, FilterEventArgs e)
    {
        Log logEntry = e.Item as Log;
        if (logEntry != null)
        {
            if (logEntry.LogWriteTime >= FilterTime)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
