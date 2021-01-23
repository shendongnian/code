    public static T AttemptAll<T>(params Func<T>[] actions)
    {
        var exceptions = new List<Exception>();
        foreach (var action in actions)
        {
            try
            {
                return action();
            }
            catch (Exception e)
            {
                exceptions.Add(e);
            }
        }
        throw new AggregateException(exceptions);
    }
