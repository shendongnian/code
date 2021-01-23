    public IEnumerator<String> GetEnumerator()
    {
        foreach (var s in _buffer.GetConsumingEnumerable())
        {
            yield return s;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
