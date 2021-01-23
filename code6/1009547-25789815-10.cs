    public Task<SomeViewModel[]> SampleFunction()
    {
        return service.GetData().selectAsync(x => new SomeViewModel
        {
            Id = x.Id,
            DateCreated = x.DateCreated,
            Data = await service.GetSomeDataById(x.Id)
        }
    }
