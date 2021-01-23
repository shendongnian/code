    async Task<Result> HandleExceptionsAsync(Task<Result> original)
    {
      try
      {
        return await original;
      }
      catch ...
    }
    public async Task<Task<Result>> MyAsyncMethod()
    {
      Task<Result> resultTask = await _mySender.PostAsync();
      return HandleExceptionsAsync(resultTask);
    }
