            Process[] oldRunningWordInstances = Process.GetProcessesByName("Microsoft Word");
			Word.Application application = new Word.Application();
			Process[] newRunningWordInstances = Process.GetProcessesByName("Microsoft Word");
			Process applicationProcess = null;
			foreach (Process p in newRunningWordInstances)
				if (!oldRunningWordInstances.Contains(p))
				{
					applicationProcess = p;
					break;
				}
			applicationProcess.Kill();
