    while (EntriesList.Count > 0)
    {
        var poppedEntries = EntriesList.Take(100).ToList<Entry>();
        EntriesList.RemoveRange(0, poppedEntries.Count);
        service.InsertEntries(poppedEntries);
        System.Threading.Thread.Sleep(5000);
    }
