    protected override void Seed(EfProgress.DatabaseEntities context)
    {
        var interceptor = new EfProgress.Program.ProgressInterceptor() { TotalCount = 10 };
        DbInterception.Add(interceptor);
        for (int i = 0; i < 10; i++)
        {
            var entity = context.EntitySet.Create();
            entity.Property1 = "entity " + i;
            context.EntitySet.Add(entity);
        }
        context.SaveChanges();
        DbInterception.Remove(interceptor);
    }
