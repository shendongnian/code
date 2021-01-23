    public async Task<SomeViewModel> Get(int id)
    {
      var someDataTask = _service.GetData(id);
      var someOtherDataTask = _service.GetMoreData(id);
      await Task.WhenAll(someDataTask, someOtherDataTask);
      return new SomeViewModel
      {
        Data = await someDataTask,
        OtherData = await someOtherDataTask,
      }
    }
