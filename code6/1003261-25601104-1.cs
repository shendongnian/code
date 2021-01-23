    void ConsumeData()
    {
        if (_inputQueue.Count < framessent.Length)
             return;
        int index = 0;
        foreach (var item in _inputQueue)
        {
            // item doesn't match?
            if (item != framessent[index++])
            {
                // data doesn't match
                OnFailed();
                return;
            }
            // reached the end of the array?
            if (index >= _inputQueue.Length)
            {
                // data matches
                OnSuccess();
                return;
            }
    }
