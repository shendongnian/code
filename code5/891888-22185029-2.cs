	public class Ticker{
		private TickHandlerObject myHandler; // injected dependency
		//bw is a background worker
        // Handle the Timer tick here:
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
