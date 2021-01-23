    List<Record> data;
    List<List<Record>> result = new List<List<Record>>();
    
    IEnumerable<Record> workingData = data;
    while (workingData.Count() > 0)
    {
        IEnumerable<Record> subList = data.Take(1).Concat(data.Skip(1).TakeWhile(c => c.Type != 'a'));
        result.Add(subList.ToList());
        workingData = workingData.Except(subList);
    }
