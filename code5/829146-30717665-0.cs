    [EnableQuery]
    public IQueryable<RegionEntity> Get()
    {
        var result = _regionService.GetAll();
        return result;
    }
