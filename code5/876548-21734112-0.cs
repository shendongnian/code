    var task = Task.Run(() => Agent.GetUserType(Instance));
    try
    {
      await task;
    }
    catch (Exception ex)
    {
      // TODO
    }
    string information = task.GetExceptionOrStatus(); // extension method
