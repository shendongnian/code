    using (var context = new EvilMutableDisposableWrapper<Context>(new Context()))
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            context.Wrapped.Collection.AddObject(line);
            if (i % 100 == 0)
            {
                context.Wrapped.SaveChanges();
                context.Dispose();
                context.Wrapped = new Context();
            }
        }
    }
