    bool m_IsRunning = true;
    public void Stop()
    {
        m_IsRunning = false;
    }
    void ProcessItems()
    {
        while(workItems.Count > 0 && m_IsRunning)
        {
                ProcessItem(workItems[0]);
        }
    }
