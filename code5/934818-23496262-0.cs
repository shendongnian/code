    private void OnTimer(object sender, ElapsedEventArgs status)
    {
        GetNewData();
    }
    
    object lockCheck = new object();
    public void GetData(ref List<double> data, int index)
    {
        lock(lockCheck)
    {
        if (index < m_data.Length)
        {
            data = new List<double>(m_data[index]);
        }
        else
        {
           data = new List<double>();
        }
    }
    }
