    public override int SaveChanges() {
    try {
        return base.SaveChanges();
    } catch (Exception ex) {
        string message = /*stuff to log from the context*/;
        using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
        {
            LogRepo.Log(msg);
        }
        throw;
    }
}
