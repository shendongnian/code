	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			// Launch itself as administrator
			ProcessStartInfo proc = new ProcessStartInfo();
			
			// this parameter is very important
			proc.UseShellExecute = true;
			
			proc.WorkingDirectory = Environment.CurrentDirectory;
			proc.FileName = Assembly.GetEntryAssembly().Location;
			// optional. Depend on your app
			proc.Arguments = this.GetCommandLine();
			proc.Verb = "runas";
			proc.UserName = "XXXX";
			proc.Password = "XXXX";
			
			try
			{
				Process elevatedProcess = Process.Start(proc);
				elevatedProcess.WaitForExit();
				exitCode = elevatedProcess.ExitCode;
			}
			catch
			{
				// The user refused the elevation.
				// Do nothing and return directly ...
				exitCode = -1;
			}
			// Quit itself
			Environment.Exit(exitCode);  
			}
		}
	}
