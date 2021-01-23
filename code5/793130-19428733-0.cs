      interface IRepositoryBase<TBackup> where TBackup : IBackup 
      {
        IEnumerable<TBackup> Backups { get; set; }
        void Delete(TBackup backup);
        TBackup GetOrCreateBackup(IFileSource source);
      }
    
      interface IRepository
      {
        IEnumerable<IBackup> Backups { get; set; }
        void Delete(IBackup backup);
        IBackup GetOrCreateBackup(IFileSource source);
      }
    
      interface IRepository<TBackup> : IRepository, IRepositoryBase<TBackup> where TBackup : IBackup 
      {
      }
