    public IEnumerable<T> GetDifferences<T>(IList<T> seq1, IList<T> seq2)
    {
        for (int i = 0; i < seq1.Count; i++)
        {
            T item1 = seq1[i];
            if(i >= seq2.Count)
                yield return item1;
            T item2 = seq2[i];
            if(!object.ReferenceEquals(item1, item2))
            {
                if (item1 == null || item2 == null)
                    yield return item1;
                else if(!item1.Equals(item2))
                    yield return item1;
            }
        }
    }
