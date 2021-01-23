    [OperationContract]
    public async Task<object> AddEntityAsync(object entity)
    {
        using(var context = new MyContext())
        {
            context.Add(entity)
            return await context.SaveChangesAsync();
        }
    }
