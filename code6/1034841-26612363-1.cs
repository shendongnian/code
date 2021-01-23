    using System.Linq;
	internal static class Program
	{
		private static void Main()
		{
			var processes = Process.GetProcessesByName( "devenv" );
			var monitors = processes.Select( p => {
				var monitor = new ProcessMonitor( p );
				monitor.NotResponding += ( s, e ) => {
					Console.WriteLine( "Process {0}(pid: {1}) has stopped responding.", e.Process.ProcessName, e.Process.Id );
				};
				
				return monitor;
			} );
			
			foreach( var monitor in monitors )
				monitor.Start();
		}
	}
