    public async Task<List<SomeViewModel>> SampleFunction()
    {
        var data = service.GetData();
    
        var transformBlock = new TransformBlock<X, SomeViewModel>(
            async x => new SomeViewModel
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Data = await service.GetSomeDataById(x.Id)
            },
            new ExecutionDataflowBlockOptions
            {
                // Let 8 "service.GetSomeDataById" calls run at once.
                MaxDegreeOfParallelism = 8
            });
    
        var result = new List<SomeViewModel>();
        var actionBlock = new ActionBlock<SomeViewModel>(
            vm => result.Add(vm));
    
        transformBlock.LinkTo(actionBlock,
            new DataflowLinkOptions { PropagateCompletion = true });
    
        foreach (var x in data)
        {
            transformBlock.Post(x);
        }
        transformBlock.Complete();
    
        await actionBlock.Completion;
    
        return result;
    }
