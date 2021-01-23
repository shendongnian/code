    Context context = null;
    try
    {
        context = new Context();
        for (int i = 0; i < numberOfLines; i++)
        {
            context.Collection.AddObject(line);
            if (i % 100 == 0)
            {
                context.SaveChanges();
                context.Dispose();
                context = new Context();
            }
        }
    }
    finally { context.Dispose(); }
