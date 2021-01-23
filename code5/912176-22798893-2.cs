    private void ReadCsv(IEnumerable<string> records)
    {
         var enumerator = records.GetEnumerator();
         enumerator.MoveNext();
         var headerRecord = enumerator.Current;
         var dataRecords = GetRemainingRecords(enumerator);
    }
    public IEnumerable<string> GetRemainingRecords(IEnumerator<string> enumerator)
    {
        while (enumerator.MoveNext())
        {
           if (enumerator.Current != null)
                yield return enumerator.Current;
        }
    }
