    // this is the shared data
    SomeDataType m_data;
    // Method that reads the data
    public void GetData(ref List<double> data, int index)
    {
        // get a reference to the existing data
        var localData = m_data;
        // only work with the localData reference here
    }
    private void OnTimer(object sender, ElapsedEventArgs status)
    {
        GetNewData();
    }
    
