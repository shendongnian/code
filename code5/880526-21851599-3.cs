    public IEnumerable<HistoryModel> Getlr()
    {
        from a in DbContext.Activities 
        return db.lr.AsEnumerable()
                    .Select(x => new HistoryModel 
                                     { 
                                         Id = x.id,
                                         Name = x.name,
                                         HistoryDescription = x.history.description,
                                         HistoryRate = x.history.rate
                                     });
    }
