    for (int ms = 50; ms < 1001; ms++)
    {
        try { DeleteFieldByArchiveId(id, field, ms); break; } catch { }
    }
    public void DeleteFieldByArchiveId(int id, string field, int TimeToWaitInMS)
    {
        var collection = _db.GetCollection("items");
        collection.Find(Query.EQ("ArchiveId", id))
            .ToList()
            .ForEach(x =>
            {
                x[field] = null;
                collection.Save(x);
                System.Threading.Thread.Sleep(TimeToWaitInMS)
            });
    }
