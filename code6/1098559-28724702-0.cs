	using System;
	using System.ComponentModel;
	using System.Threading;
	namespace ConsoleApplication1
	{
		internal class Program
		{
			private static void Main()
			{
				// Create our listener and start listening...
				var sammpleListener = new SampleListener();
				sammpleListener.StartListening();
				// Run forever...
				Console.WriteLine("Waiting for players to join...");
				Console.WriteLine("Press Ctrl+C to stop!");
				for (var counter = 1;; counter++)
				{
					Console.WriteLine("Main thread working: {0}...", counter);
					Thread.Sleep(200);
				}
			}
			internal class SampleListener
			{
				private readonly BackgroundWorker _udpWaitForPlayer;
				public SampleListener()
				{
					_udpWaitForPlayer = new BackgroundWorker();
					_udpWaitForPlayer.DoWork += _udpWaitForPlayer_DoWork;
				}
				public void StartListening()
				{
					_udpWaitForPlayer.RunWorkerAsync();
				}
				private void _udpWaitForPlayer_DoWork(object sender, DoWorkEventArgs e)
				{
					const int junkSample = 10;
					for (var i = 1; i <= junkSample; i++)
					{
						// Notice how this doesn't make the main thread sleep / hang...
						Console.WriteLine("Background worker working: {0} of {1}...", i, junkSample);
						Thread.Sleep(1000);
					}
					Console.WriteLine("Background worker: Finished!");
				}
			}
		}
	}
