    public void IEnumerable<T> PrependBeforeRow(IEnumerable<T> A, IEnumerable<T> B)
    {
        foreach (var b in B)
        {
            foreach (var a in A)
            {
                yield return a;
            }
        
            yield return b;
        }
    }
