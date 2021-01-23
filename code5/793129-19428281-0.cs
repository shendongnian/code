    internal class BackupType : IBackup { }
    
        internal interface IFileSource { }
    
        internal interface IBackup { }
    
        interface IRepository<TBackup> where TBackup : IBackup
        {
            IEnumerable<TBackup> Backups { get; set; }
            void Delete(TBackup backup);
            TBackup GetOrCreateBackup(IFileSource source);
        }
    
        interface IRepository : IRepository<IBackup> { }
        interface IRepositoryBackupType : IRepository<BackupType> { }
    
        class RepositoryBackupType:IRepository,IRepositoryBackupType
        {
        ... (implementation of both interfaces)
        }
