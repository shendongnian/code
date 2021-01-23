    private IEnumerator<string> m_iterator;
        
    public bool MoveNext()
    {
        if (this.m_iterator == null)
        {
            this.ResetIterator();
        }
        return this.m_iterator.MoveNext();        
    }
    public string Current
    {
        get
        {
            if (this.m_iterator == null)
            {
                this.Reset();
            }
            return this.m_iterator.Current;
        }
    }
    public void Reset()
    {
        this.m_iterator = this.m_internalIterator();
    }
    private IEnumerator<string> m_internalIterator()
    {
        for (int i = 0; i < m_list.Count; i++)
        {
            yield return m_list[i];
        }
        yield break;
    }
