    public IEnumerator GetEnumerator()
    {
        var enumerator = days.GetEnumerator();
        enumerator.MoveNext();
        yield return enumerator.Current;
    }
