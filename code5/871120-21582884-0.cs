    public IEnumerator<List<EngineToken>> GetEnumerator()
    {
        string input = string.Empty;
        int i=0;
        List<string> batch = new List<string>();
        foreach(var item in EngineTokens)
        {
            batch.Add(item);
            i++;
            if(i==_batchSize)
            {
                 yield return batch;
                 batch = new List<string>();
                 i = 0;
            }
        }
        if (batch.Count != 0)
        {
            yield return batch;
        }
    }
