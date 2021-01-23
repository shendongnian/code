    private void Check()
    {
        while (true)
        {
            if (!m_Enabled)
                return;
            
            Thread.Sleep(10); //10 millisecond resolution for this timer
            if (Environment.TickCount > m_InitialTickCount + m_Interval)
            {
                OnFinished(EventArgs.Empty);
                return;
            }
        }
    }
