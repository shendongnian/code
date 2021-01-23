    public WaitHandle WaitHandle
    {
        get
        {
            if (m_source == null)
            {
                 m_source = CancellationTokenSource.InternalGetStaticSource(false);
            }
            return m_source.WaitHandle;
        }
    }
