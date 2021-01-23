    public void Edit(TEntity config)
    {
        Context.Attach<TEntity>(config);
        Context.Entry<TEntity>(config).State = EntityState.Modified;
        foreach(var df in config.DataFields)
        {
            Context.Entry<DataField>(df).State = EntityState.Modified;
        }
        // I noticed you never saved the changes to the DbContext. Do you need
        // to do this here, or are you doing it with your UOW somewhere else??
        Context.SaveChanges();
    }
