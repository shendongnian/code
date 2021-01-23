    IEnumerable<object[]> GetAsEnumerable(MultiDimDictList table)
    {
      yield return table.Columns.Select(i => (object)i.Name).ToArray();
    
      foreach (var row in table)
      {
        yield return table.Columns.Select(i => (object)row[i.Name]).ToArray();
      }
    }
