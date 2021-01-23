	public class Ticker{
		// This class has the timer and the OnTimedEevent is the tick event
		private TickHandlerObject myHandler; // injected dependency
		//bw is a background worker
        // On tick event handler
        // Run the background worker to get the data.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
			if (myHandler.IsBusy == false) // check here if the handler is still running
			{
				if (bw.IsBusy)
				{
					Console.WriteLine("Background worker is busy....\n");
				}
				else
				{
					bw.RunWorkerAsync();
				}
			}
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                // raise event to be handled by myHanlder object
                Updated();
            }
        }
	}
