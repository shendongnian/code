    public void IEnumerable<T> PrependBeforeRow(IEnumerable<T> A, IEnumerable<T> B)
    {
        foreach (var b in B)
        {
            foreach (var a in A)
            {
                yield return a;      // <-- first iterate over A and return all items
            }
        
            yield return b;      // <-- the yield the current item from B
        }
    }
