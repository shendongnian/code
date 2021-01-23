    private async Task<string> GetByIdFrom<T>(EntityArgs args)
        where T : Entity
    {
        T entity = await (new Repository<T>()).GetByKeyAsync(args.Id);
        if (entity != null)
            return entity.Content;
        return null;
    }
