    using namespacetoextensions;
    public ActionConfirmation<string> CreateUpdateEntity<TExternalEntity, TQuickbooksEntity>(TExternalEntity entity, CompanyPreferencesFinancialsSystemCommon preferences)
        where TExternalEntity : class, OTIS.Domain.IEntity, IFinancials, new()
        where TQuickbooksEntity : class, Intuit.Ipp.Data.IEntity, new()
    {
        return CreateUpdateQuickBooksEntity<TQuickbooksEntity>(
            entity.ToQuickBooksEntity(preferences),
            x => x.Id == entity.FinancialsId,
            entity.FinancialsId);
    }
