    private Task<TResult> DoGenericStuff<TDbContext, TResult>(Func<TDbContext, TResult> func) where TDbContext : DbContext, new()
    {
        return Task.Factory.StartNew(() =>
        {
            using (var context = new TDbContext())
            {
                return func(context);
            }
        });
    }
