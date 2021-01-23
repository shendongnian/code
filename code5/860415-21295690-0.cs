    public IEnumerable<IEnumerable<T>> Partition<T>(IEnumerable<T> source, int size)
    {
        var partition = new List<T>(size);
        var counter = 0;
    
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                partition.Add(enumerator.Current);
                counter++;
                if (counter % size == 0)
                {
                    yield return partition.ToList();
                    partition.Clear();
                    counter = 0;
                }
            }
    
            if (counter != 0)
                yield return partition;
        }
    }
