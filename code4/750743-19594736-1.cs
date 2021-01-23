    public override int SaveChanges() {
        try {
            return base.SaveChanges();
        } catch (Exception ex) {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                LogRepo.Log(message); // stuff to log from the context
            }
            throw;
        }
    }
