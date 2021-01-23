    private void Set_status(string text, string Qmgr)
    {
        if (this.Status1A.InvokeRequired)
        {
            this.Invoke((Action)(() => Set_status(text, Qmgr)));
        }
        else
        {
