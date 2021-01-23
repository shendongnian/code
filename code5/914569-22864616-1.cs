    public static async void Forget(this Task task, params Type[] acceptableExceptions)
    {
      try
      {
        await task.ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        // TODO: consider whether derived types are also acceptable.
        if (!acceptableExceptions.Contains(ex.GetType()))
          throw;
      }
    }
