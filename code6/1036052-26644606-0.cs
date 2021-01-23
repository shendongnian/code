    // Must implement GetEnumerator, which returns a new StreamReaderEnumerator. 
    public IEnumerator<string> GetEnumerator()
    {
        return new StreamReaderEnumerator(_filePath);
    }
    
    // Must also implement IEnumerable.GetEnumerator, but implement as a private method. 
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
