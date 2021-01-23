    public Task<SomeViewModel[]> SampleFunction()
    {
        return service.GetData().SelectAsync(x => new SomeViewModel
        {
            Id = x.Id,
            DateCreated = x.DateCreated,
            Data = await service.GetSomeDataById(x.Id)
        }
    }
