    public async Task WaitForThreadsToCompleteAsync(Object _Item) 
    {
      var results = await Task.WhenAll(
        Task.Run(() => InitiateBackgroundProcessElements(_Item.Id)),
        Task.Run(() => InitiateBackgroundProcessCompulsoryField(_Item.Id)),
        Task.Run(() => InitiateBackgroundProcessFieldRange(_Item.Id)));
      // my logic here
    }
