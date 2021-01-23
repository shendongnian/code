    serviceInstaller.ServiceName = "KFolderWatcher";
    public class KFolderWatcher : ServiceBase
    {
        //public const string MyServiceName = "KFolderWatcher";
        private FileSystemWatcher watcher = null;
    
        public KFolderWatcher()
        {
          //  this.ServiceName = "KFolderWatcher";
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true;
        }
    
        protected override void OnStart(string[] args)
        {
           // this.ServiceName = MyServiceName;
     .....
