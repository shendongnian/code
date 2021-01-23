    public IQueryable<ChildData> GetChildData(int mainClassId)
    
    using (var ctx = Csla.Data.ObjectContextManager<DB.Data.Entities>.GetManager(Model.EntitiesDatabase.Name))
    {
        return ctx.ObjectContext.ChildData.Where(x => x.MainClassId == mainClassId);
    }
