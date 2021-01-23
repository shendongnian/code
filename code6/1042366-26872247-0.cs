    using System.Collections.Generic;
    using Timer = System.Timers.Timer;
    public partial class VsiFtpManager : ServiceBase
    {
		private Timer _searchTimer;
		private Queue<string> _filesToProcess;
		private string _ftpRoot; //this is set elsewhere from the registry
		
		protected override void OnStart(string[] args)
        {
		
			//process any files that are already there when the service starts
			LoadExistingFtpFiles(); 
			
			//Handle new files
			_searchTimer = new Timer(10000);
            _searchTimer.Elapsed += LoadExistingFtpFiles;
		}
		
		//convenience overload to allow this to handle timer events
        private void LoadExistingFtpFiles(object source, ElapsedEventArgs evtArgs)
        {
            LoadExistingFtpFiles();
        }
        private void LoadExistingFtpFiles()
        {
            _searchTimer.Stop();
            var di = new DirectoryInfo(_ftpRoot);
            FileInfo[] fileInfos = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo fi in fileInfos.Where(fi => fi != null))
            {
                if (fi.Extension != "processed" && !_filesToProcess.Contains(fi.FullName))
                {
                    LogHelper.BroadcastLogMessage("INFO:  File " + fi.Name + " was uploaded.", EventLogEntryType.Information);
                    _filesToProcess.Enqueue(fi.FullName);
                    LogHelper.BroadcastLogMessage("File received: " + fi.Name, EventLogEntryType.Information);
                }
            }
            _searchTimer.Start();
        }
	}
