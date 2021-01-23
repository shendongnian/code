    public ICB GetICB(int id)
    {
        return GetDbSet<ICB>()
            .Include("ICBResources")
            .SingleOrDefault(i => i.ICBId == id && i.ICBResources.Where(r => !r.Deleted).Count() == 0);
    }
