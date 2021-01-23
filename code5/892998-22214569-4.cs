    public static class Extensions
    {
        public static TExternalEntity ToQuickBooksEntity<TExternalEntity, TQuickbooksEntity>(this TQuickbooksEntity externalEntity)
            where TExternalEntity : class, OTIS.Domain.IEntity, new()
            where TQuickbooksEntity : class, Intuit.Ipp.Data.IEntity, new()
        {
            throw new NotImplementedException();
        }
    }
