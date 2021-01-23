    int current = 0;
    int batchSize = 100;
    while (current < EntriesList.Count)
    {
        service.InsertEntries(EntriesList.Skip(current).Take(batchSize).ToList());
        current += batchSize;
        System.Threading.Thread.Sleep(5000);
    }
