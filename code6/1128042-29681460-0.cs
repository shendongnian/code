    public void UpdateBoxes(Session s, DataTable dt, Action<ProgressInfo> updateProgress)
    {
        for (...)
        {
            ...
            updateProgress(new ProgressInfo(...));
        }
    }
