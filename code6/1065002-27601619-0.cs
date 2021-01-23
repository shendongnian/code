    public IEnumerable<int> Method2(Func<Exception, bool> handler)
    {
        foreach (var item in collection)
        {
            try
            {
                // ...
            }
            catch (Exception ex)
            {
                if (!handler(ex))
                    throw;
            }
        }
    }
