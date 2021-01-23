    void ConsumeData()
    {
        while (_inputQueue.Count < framessent.Length)
        {
            int index = 0;
            bool success = false;
            foreach (var item in _inputQueue)
            {
                // item doesn't match?
                if (item != framessent[index++])
                {
                    // data doesn't match
                    success = false;
                    break;
                }
                // reached the end of the array?
                if (index >= _inputQueue.Length)
                {
                    // data matches
                    success = true;
                    break;
                }
            }
            
            if (success)
            {
                OnSuccess();
                return;
            }
            else
            {
                // remove first byte and retry
                _inputQueue.Dequeue();
            }
        }
    }
