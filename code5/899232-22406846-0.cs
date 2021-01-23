    public static async Task<TException> ThrowAsync<TException>(Func<Task> actual)
        where TException : Exception
    {
      try
      {
        await actual();
      }
      catch (TException e)
      {
        return e;
      }
      catch (Exception e)
      {
        throw new ChuckedAWobbly(new ShouldlyMessage(typeof(TException), e.GetType()).ToString());
      }
      throw new ChuckedAWobbly(new ShouldlyMessage(typeof(TException)).ToString());
    }
