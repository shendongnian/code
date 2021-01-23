    public Task<SomeViewModel[]> SampleFunction()
    {
        return Task.WhenAll(service.GetData().Select(
            async x => new SomeViewModel
        {
            Id = x.Id,
            DateCreated = x.DateCreated,
            Data = await service.GetSomeDataById(x.Id)
        }));
    }
