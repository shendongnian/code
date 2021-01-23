    public MyDatabaseContext : DbContext
    {
        private readonly IAuditDatabaseChange _auditDatabaseChange;
        static CommonDatabaseContext()
        {
            Database.SetInitializer<CommonDatabaseContext>(null);
        }
        public CommonDatabaseContext() {
            _runningMigrations = true;
        }
        public CommonDatabaseContext(IAuditDatabaseChange auditService)
        {
            _auditDatabaseChangeService = auditService;
            _runningMigrations = false;
        }
        public override async Task<int> SaveChangesAsync()
        {
            if (!_runningMigrations)
            {
                await _auditDatabaseChange.SaveAudit(this);
            }
            return await base.SaveChangesAsync();
        }
        public override int SaveChanges()
        {
            if (!_runningMigrations)
            {
                Task.Run(() => _auditDatabaseChange.SaveAudit(this)).Wait();
            }
            return base.SaveChanges();
        }
    }
