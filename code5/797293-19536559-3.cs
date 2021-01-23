    public IEnumerator GetEnumerator()
    {
        var enumerator = days.GetEnumerator();
        while(enumerator.MoveNext()){
           yield return enumerator.Current;
        }
    }
