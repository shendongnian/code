    myList.AddRange(await Task.WhenAll(data.Select(async x => new SomeViewModel
    {
        Id = x.Id,
        DateCreated = x.DateCreated,
        Data = await service.GetSomeDataById(x.Id)
    })));
