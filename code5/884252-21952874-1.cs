    public void MyMethodToProcess(List<int> data, int requestID)
    {
        idToProgress.Add(requestID, 0);
        for (int i = 0; i < data.Count; i++)
        {
            prossessData(data.ElementAt(i));
            idToProgress[requestID] += 100/(double)data.Count; //Updates the progress.
        }
    }
    
    ConcurrentDictionary<int, double> idToProgress = new ConcurrentDictionary<int, double>();
