    namespace Fle.SQLServer.XmlFiles.Notifier
    {
      public class XmlSerialization<T> : INotifier
      {
        readonly IRepository<T> field;
    
        public XmlSerialization(IRepository<T> repository)
        {
          field = repository;
        }
    
    
        public void Notify()
        {         
          field.Save();     
        }      
      }
    }
    public class Registry : Autofac.Module
      {
        protected override void Load(ContainerBuilder builder)
        {
          builder.RegisterType<XmlSerialization<BackupDeviceLocationData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<BackupHistoryData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<BelongToSystemData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DatabaseLongRunningJobData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DatabaseOwnerData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DatabaseReplicationData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DatabaseSizesData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DatabaseSystemData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<DiskBackupData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<FailedDatabaseJobsData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<RecoveryModelData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<SqlServerAgentEventLogData>>().As<INotifier>();
          builder.RegisterType<XmlSerialization<SqlServerEventLogData>>().As<INotifier>();
        }
    }
