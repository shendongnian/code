    public class LogContext : DbContext
    {
        private readonly Func<string> _getAdditionalInfoFunc;
        public LogContext(string context, Func<string> getAdditionalInfoFunc)
            : base(context)
        {
                _getAdditionalInfoFunc = getAdditionalInfoFunc;
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                        .Where(x => x.State == EntityState.Added).ToList();
            var modified = ChangeTracker.Entries()
                        .Where(x => x.State == EntityState.Modified).ToList();
            var deleted = ChangeTracker.Entries()
                        .Where(x => x.State == EntityState.Deleted).ToList();
            string extraInfo = _getAdditionalInfoFunc != null
                             ? _getAdditionalInfoFunc()
                             : string.Empty;
            Logger.RecordAdded(added, extraInfo);
            Logger.RecordModified(modified, extraInfo);
            Logger.RecordDeleted(deleted, extraInfo);
        }
    } 
