    public static async Task LoadAsync<T>(ICollection<T> collection)
        where T : class
    {
        if (collection == null) throw new ArgumentNullException("collection");
        var entityCollection = collection as System.Data.Entity.Core.Objects.DataClasses.EntityCollection<T>;
        if (entityCollection == null || entityCollection.IsLoaded) return;
        await entityCollection.LoadAsync(CancellationToken.None).ConfigureAwait(false);
    }
